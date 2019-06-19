using Achele.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achele.Infraestructure
{
    public class InstanceLocator
    {
        #region Properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = MainViewModel.GetInstance();
        }
        #endregion
    }
}