using System.ComponentModel;
using DevExpress.XtraEditors;
using NUnit.Framework;
using SCOUT.WinForms.Controls;

namespace SCOUT.Tests.UI
{
    [TestFixture]
    public class ButtonStateControllerTests
    {

        [Test]
        public void  when_disable_conditions_are_present()
        {
            var button = new SimpleButton();
            var model = new TestModel();
            var controller = new ControlStateController<TestModel>(button, model);

            controller.AddDisableCondition((m) => m.Name == "Test");

            model.Name = "Test";
            Assert.That(controller.IsEnabled() == false);
        }
        
    }

    public class TestModel : INotifyPropertyChanged
    {
        private string m_name;

        public string Name 
        {
            get { return m_name; }    
            set
            {
                m_name = value;
                RaisePropertyChanged("Name");
            }
                    
        } 
        
        private void RaisePropertyChanged(string property)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    }
}