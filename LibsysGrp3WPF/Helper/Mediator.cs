using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using UtilLibrary.MsSqlRepsoitory;

namespace LibsysGrp3WPF
{
    public static class Mediator
    {
        // Dictionary to couple page names in string with
        // page ENUM
        public static Dictionary<PagesChoice, string> PagesChoiceToStringName = new Dictionary<PagesChoice, string>
        {

            { PagesChoice.pageStartView, "Startsida" },
            { PagesChoice.pageManageVisitor, "Hantera Besökare" },
            { PagesChoice.pageReport, "Rapportera Objekt" },
            { PagesChoice.pageManageBook, "Hantera Objekt" },
            { PagesChoice.pageManageSeminar, "Hantera Seminarier" },
            { PagesChoice.pageManageUsers, "Hantera Användare" },
            { PagesChoice.pageVisitorEditProfil, "Ändra Profil" },
            { PagesChoice.pageVisitorMyItems, "Mina Lån" },
            { PagesChoice.pageVisitorSearch, "Låna Objekt" },
            { PagesChoice.pageManageCheckIn, "Återlämna Objekt" },
            { PagesChoice.pageManageStock, "Hantera Lager" },
            { PagesChoice.pageVisitorSeminar, "Seminarier" },
        };

        // Global user, so user can be accessed across views
        public static UsersModel User = null;

        private static IDictionary<PagesChoice, List<Action<object>>> pl_dict =
           new Dictionary<PagesChoice, List<Action<object>>>();

        public static void Subscribe(PagesChoice token, Action<object> callback)
        {
            if (!pl_dict.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                pl_dict.Add(token, list);
            }
            else
            {
                bool found = false;
                foreach (var item in pl_dict[token])
                    if (item.Method.ToString() == callback.Method.ToString())
                        found = true;
                if (!found)
                    pl_dict[token].Add(callback);
            }
        }

        public static void Unsubscribe(PagesChoice token, Action<object> callback)
        {
            if (pl_dict.ContainsKey(token))
                pl_dict[token].Remove(callback);
        }

        public static void Notify(PagesChoice token, object args = null)
        {
            if (pl_dict.ContainsKey(token))
                foreach (var callback in pl_dict[token])
                    callback(args);
        }

        public static void CloseApplication()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
