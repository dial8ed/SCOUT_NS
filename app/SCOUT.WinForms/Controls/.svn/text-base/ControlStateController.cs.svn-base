using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SCOUT.WinForms.Controls
{
    public class ControlStateController<TModel> where TModel : INotifyPropertyChanged
    {
        private Control m_button;
       
        private List<Func<TModel, bool>> m_disableConditions;
        private TModel m_model;

        public ControlStateController(Control button, TModel model)
        {
            m_button = button;
            m_model = model;            
            model.PropertyChanged += (s, e) => SetState(m_model);
            m_disableConditions = new List<Func<TModel, bool>>();
        }

        public void AddDisableCondition(Func<TModel,bool> disableWhen)
        {        
            m_disableConditions.Add(disableWhen);
        }

        public void SetState(TModel model)
        {
            m_button.Enabled = m_disableConditions.Count(c => c(model)) == 0;
        }

        public bool IsEnabled()
        {
            return m_button.Enabled;
        }

    }
}