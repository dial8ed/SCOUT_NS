using System;
using System.Security.Cryptography;
using System.Text;

namespace SCOUT.Core.Security
{
    public partial class Security
    {
        public class Password
        {
            #region Member Variables & Constants

            /*
             * WARNING: Chaning this constant will _BREAK_ any existing passwords!
             */
            private const int SALT_LENGTH = 8;

            private byte[] m_encrypted = null;

            #endregion

            #region Constructors/Destructor

            public Password()
            {
            }

            public Password(string text)
            {
                m_encrypted = Encrypt(text);
            }

            public Password(byte[] data)
            {
                if ((data != null) && (data.Length > SALT_LENGTH))
                {
                    m_encrypted = new byte[data.Length];
                    Buffer.BlockCopy(data, 0, m_encrypted, 0, data.Length);
                }
            }

            public Password(Password pwd)
            {
                if (pwd.m_encrypted != null)
                {
                    m_encrypted = new byte[pwd.m_encrypted.Length];
                    Buffer.BlockCopy(pwd.m_encrypted, 0, m_encrypted, 0,
                                     pwd.m_encrypted.Length);
                }
            }

            public Password(string text, Password saltFrom)
            {
                byte[] salt = ExtractSalt(saltFrom.m_encrypted);
                m_encrypted = EncryptWithSalt(text, salt);
            }

            #endregion

            #region Properties

            public string ClearText
            {
                // Write only for security.  Read from EncryptedData.
                set
                {
                    if (value.Trim() == String.Empty)
                        m_encrypted = null;
                    else
                        m_encrypted = Encrypt(value);
                }
            }

            public byte[] EncryptedData
            {
                // Read only for security.  Write to ClearText.
                get
                {
                    return m_encrypted;
                }
            }

            public bool IsEmpty
            {
                get { return (m_encrypted == null); }
            }

            #endregion

            #region Helpers

            #region Compairson

            private bool EqualsPassword(Password pwd)
            {
                // Quick check
                if ((m_encrypted == null) ||
                    (pwd.m_encrypted == null) ||
                    (pwd.m_encrypted.Length != m_encrypted.Length))
                {
                    return false;
                }

                bool rval = true;

                for (int i = 0; (i < m_encrypted.Length) && rval; ++i)
                    rval &= (pwd.m_encrypted[i] == m_encrypted[i]);

                return rval;
            }

            private bool EqualsString(string str)
            {
                if (m_encrypted == null)
                    return false;

                Password tmp = new Password(str, this);

                return EqualsPassword(tmp);
            }

            #endregion

            #region Salt

            static private byte[] GenerateSalt()
            {
                RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
                byte[] randBytes = new byte[SALT_LENGTH];

                rand.GetBytes(randBytes);

                return randBytes;
            }

            static private byte[] ExtractSalt(byte[] data)
            {
                byte[] rval = new byte[SALT_LENGTH];

                if ((data == null) || (data.Length < SALT_LENGTH + 1))
                    throw new Exception("Invalid password.");

                Buffer.BlockCopy(data, 0, rval, 0, SALT_LENGTH);
                return rval;
            }

            #endregion

            #region Encryption

            static private byte[] EncryptWithSalt(string text, byte[] salt)
            {
                if (string.IsNullOrEmpty(text))
                    return null;

                byte[] pwd = Encoding.Unicode.GetBytes(text);
                byte[] rval = null;

                TripleDESCryptoServiceProvider tdes =
                    new TripleDESCryptoServiceProvider();

                try
                {
                    PasswordDeriveBytes pdb = new PasswordDeriveBytes(pwd, salt);

                    byte[] tmp = pdb.CryptDeriveKey("TripleDES", "SHA1",
                                                    192, tdes.IV);

                    rval = new byte[tmp.Length + salt.Length];

                    Buffer.BlockCopy(salt, 0, rval, 0, salt.Length);
                    Buffer.BlockCopy(tmp, 0, rval, salt.Length, tmp.Length);
                }
                finally
                {
                    Buffer.SetByte(pwd, 0, 0);
                    Buffer.SetByte(salt, 0, 0);
                }

                return rval;
            }

            static private byte[] Encrypt(string text)
            {
                byte[] salt = GenerateSalt();
                return EncryptWithSalt(text, salt);
            }

            #endregion

            #endregion

            #region Object Overloads

            public override bool Equals(object obj)
            {
                string s = obj as String;

                if (s != null)
                    return EqualsString(s);
                else
                {
                    if (obj.GetType() == typeof(Password))
                    {
                        Password pwd = obj as Password;
                        return EqualsPassword(pwd);
                    }
                }

                return false;
            }

            public override int GetHashCode()
            {
                return m_encrypted.GetHashCode();
            }

            #endregion

            #region Operator Overloads

            static public implicit operator Password(string str)
            {
                return new Password(str);
            }

            static public bool operator ==(Password pwd, string str)
            {
                return pwd.EqualsString(str);
            }

            static public bool operator !=(Password pwd, string str)
            {
                return !pwd.EqualsString(str);
            }

            static public bool operator ==(string str, Password pwd)
            {
                return pwd.EqualsString(str);
            }

            static public bool operator !=(string str, Password pwd)
            {
                return !pwd.EqualsString(str);
            }

            static public bool operator ==(Password lhs, Password rhs)
            {
                return lhs.EqualsPassword(rhs);
            }

            static public bool operator !=(Password lhs, Password rhs)
            {
                return !lhs.EqualsPassword(rhs);
            }

            #endregion
        }
    }
}