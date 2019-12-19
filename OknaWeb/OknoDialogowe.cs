using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestyInterfejsowe.OknaWeb
{
    class OknoDialogowe : AbstractWindow
    {
        public OknoDialogowe(RemoteWebDriver driver) : base(driver)
        {
        }
    }
}
