using System;
using SCOUT.Core.Data;

namespace SCOUT.WinForms.Core
{
    public class MaterialsConfigurePartCommand : Command
    {
        private Part m_part;

        public MaterialsConfigurePartCommand(params object[] input) : base(input)
        {
            m_part = input[0] as Part;

            if(m_part == null)
                throw new InvalidCastException("The constructor argument passed to MaterialsConfigurePartCommand was not of type Part.");
        }

        public override void Execute()
        {
            
        }
    }
}