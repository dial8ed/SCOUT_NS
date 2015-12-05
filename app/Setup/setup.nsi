;--------------------------------
; scout_ns.nsi
;
; It will install SCOUT NS into a directory that the user selects.
;--------------------------------

!ifdef ALPHA
    !define APP_NAME "SCOUT NS (Alpha)"
    !define APP_DIR "SCOUT_NS_ALPHA"
    !define OUT_DIR "Alpha"
!else
    !define APP_NAME "SCOUT NS"
    !define APP_DIR "SCOUT_NS"
    !define OUT_DIR "Release"
!endif

!define COMP_DIR "STS"
!define FULL_DIR "${COMP_DIR}\${APP_DIR}"

!define SETUP_NAME "${APP_NAME} Setup"

; The name of the installer
Name "${SETUP_NAME}"

; The file to write
OutFile "${OUT_DIR}\${APP_NAME} Setup.exe"

; The default installation directory
InstallDir $PROGRAMFILES\${FULL_DIR}

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
;
; WARNING:
; If you update this value besure to also update the Launcher so 
; it can find SCOUT!
InstallDirRegKey HKLM "Software\${FULL_DIR}" "Install_Dir"

; Request application privileges for Windows Vista
RequestExecutionLevel admin
XPStyle on

;SetCompressor /SOLID lzma

;--------------------------------
; Functions

Function IsDotNETInstalled
    Push $0
    Push $1

    StrCpy $0 1
    System::Call "mscoree::GetCORVersion(w, i ${NSIS_MAX_STRLEN}, *i) i .r1"

    StrCmp $1 0 +2
	StrCpy $0 0
    	
    Pop $1
    Exch $0
FunctionEnd

;--------------------------------
; Pages

Page directory
Page instfiles

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------
; The stuff to install

Section
SectionIn RO
    	
    Call IsDotNETInstalled
    pop $0
    StrCmp $0 1 +3
	messageBox MB_OK "You must have the Microsoft .NET Framework 2.0 installed."
	return
    	
    SetShellVarContext all

    ; Set output path to the installation directory.
    SetOutPath $INSTDIR

    ; Files to install
    File ${BUILD_OUTPUT}\SCOUT.UI.exe
    File /r ${BUILD_OUTPUT}\*.dll
    File /r ${BUILD_OUTPUT}\*.config
    File /nonfatal /r ${BUILD_OUTPUT}\*.xml

    ; DevExpress files to install
    ;
    ; We are not allowed to redistribute the DevExpress.*.Design.dll files.
    ;
    ; The web files are excluded because they are not needed for the client
    ; which helps to keep the installer size down.
    File \
	/x DevExpress.*.Design.dll \
	/x DevExpress.Web.*.dll \
	/x DevExpress.*.Web.dll \
	${BUILD_OUTPUT}\..\..\..\..\tools\DevExpress\DevExpress.DLL\DevExpress.*.dll

    ; Write the installation path into the registry
    WriteRegStr HKLM SOFTWARE\${FULL_DIR} "Install_Dir" "$INSTDIR"

    ; Write the uninstall keys for Windows
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP_DIR}" "DisplayName" "${APP_NAME}"
    WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP_DIR}" "UninstallString" '"$INSTDIR\uninstall.exe"'
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP_DIR}" "NoModify" 1
    WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP_DIR}" "NoRepair" 1
    WriteUninstaller "uninstall.exe"
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"
    CreateShortCut "$SMPROGRAMS\${APP_NAME}.lnk" \
	"$INSTDIR\SCOUT.UI.exe" "" \
	"$INSTDIR\SCOUT.UI.exe" 0
	
    CreateShortCut "$DESKTOP\${APP_NAME}.lnk" \
	"$INSTDIR\SCOUT.UI.exe" "" \
	"$INSTDIR\SCOUT.UI.exe" 0
SectionEnd

;--------------------------------
; Uninstaller

Section "Uninstall"
    SetShellVarContext all

    ; Remove registry keys
    DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP_DIR}"
    DeleteRegKey HKLM SOFTWARE\${FULL_DIR}

    ; Remove files and uninstaller
    Delete $INSTDIR\SCOUT.UI.exe
    Delete $INSTDIR\*.dll
    Delete $INSTDIR\*.config
    Delete $INSTDIR\*.xml
    	
    Delete $INSTDIR\uninstall.exe

    ; Remove shortcuts, if any
    Delete "$DESKTOP\${APP_NAME}.lnk"
    Delete "$SMPROGRAMS\${APP_NAME}.lnk"

    ; Remove directories used
    RMDir /r $INSTDIR
SectionEnd
