using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_YounesBenzian
{
    internal class Magazine: ReadingRoomItem
    {
		private byte month;

		public byte Month
		{
			get { return month; }
			set 
			{
                if (value > 12)
                {
                    Console.WriteLine("De maand is maximaal 12");
                }
                else
                {
                    this.month = value;
                }
            }
		}

        private uint year;
        public uint Year
        {
            get { return year; }
            set
            {
                if (value > 2500)
                {
                    Console.WriteLine("Het jaartal is maximaal 2500");
                }
                else
                {
                    this.year = value;
                }
            }
        }

      
        public Magazine(string title, string publisher, byte month, uint year) : base(title, publisher)
        {
            this.Month = month;
            this.Year = year;

        }

      

        private string GetInitials(string text)
        {
            string[] words = text.Split(' ');
            string initials = "";
            foreach (string word in words)
            {
                initials += word.Substring(0, Math.Min(2, word.Length)); //Feedback veranderd in 2
            }
            return initials.ToUpper();
        }
        public override string Identification
        {
            get
            {
                string initials = GetInitials(Title);
                string datePart = Month.ToString("00") + Year.ToString("0000");
                return initials + datePart;
            }
        }

        public override string Categorie
        {
            get
            {
                return "Maandblad";
            }
        }

    }
}
