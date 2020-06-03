using System;
using System.Collections.Generic;
using System.Text;

namespace LibsysGrp3WPF
{
    /// <summary>
    /// Just an interface to the ViewModels
    /// </summary>
    public interface IPageViewModel
    {
        /// <summary>
        /// Because of how our navigation works, we have to do so everytime we change the view this method runs.
        /// Works as kind of a constructor.
        /// </summary>
        public void Run();
    }
}
