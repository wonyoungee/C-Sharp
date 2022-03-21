using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Ticketing
{
    [Serializable]
    public class User
    {
        private string id;
        private string pwd;
        private int mileage;
        private int cash;

        public User(string id, string pwd)
        {
            this.id = id;
            this.pwd = pwd;
        }
        public string Id
        {
            get { return this.id; }

            set { this.id = value; }
        }
        public string Pwd
        {
            get { return this.pwd; }

            set { this.pwd = value; }
        }
        public int Mileage
        {
            get { return this.mileage; }

            set { this.mileage = value; }
        }
        public int Cash
        {
            get { return cash; }

            set { cash = value; }
        }
    }
}
