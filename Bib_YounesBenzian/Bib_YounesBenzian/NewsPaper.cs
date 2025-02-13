using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_YounesBenzian
{

    internal class NewsPaper : ReadingRoomItem
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { this.date = value; }
        }

        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            this.date = date;
        }


        private string GetInitials(string title)
        {
            if (title != null)
            {
                string[] words = title.Split(' ');
                string initials = "";
                foreach (string word in words)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        initials += word[0];
                    }
                }
                return initials.ToUpper();
            }
            else
            {
                
                return ""; 
            }
        }
        public override string Identification
        {
            get
            {
                string initials = GetInitials(Title);
                string datePart = date.ToString("ddMMyyyy");
                return initials + datePart;
            }
        }

        public override string Categorie
        {
            get
            {
                return "Krant";
            }
        }

        
    }

}
