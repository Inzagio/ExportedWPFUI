using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;

namespace WPFUI.ViewModels
{
   public class SecondChildViewModel : Screen
    {
        private BindableCollection<TextBox> _textbox1 = new BindableCollection<TextBox>();

        public BindableCollection<TextBox> TextBox1
        {
            get => _textbox1;
            set
            {
                _textbox1 = TextBox1;
                NotifyOfPropertyChange( () => TextBox1);
            }
        }

       
       
    }
}
