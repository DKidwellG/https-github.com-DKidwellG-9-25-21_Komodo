using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    class DevRepo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short ID { get; set; }
        public bool AccessToPluralsight { get; set; }
        public DevRepo() { }
        public DevRepo(string firstName,string lastName,short id,bool accessToPluralsite)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            AccessToPluralsight = accessToPluralsite;


        }
        private List<DevRepo> _listOfDev = new List<DevRepo>();
        //create
        public void AddDevToList(DevRepo dev)
        {
            _listOfDev.Add(dev);
        }

        //read
        public List<DevRepo> GetDev()
        {
            return _listOfDev;
        }

        //update
        public bool UpdateExistingDev(short originalDev, DevRepo newDev)
        {
            //find
            DevRepo oldDev = GetDevById(originalDev);

            //update
            if (oldDev != null)
            {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.ID = newDev.ID;
                oldDev.AccessToPluralsight = newDev.AccessToPluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }


        //delete
        public bool RemoveDevFromList(short id)
        {
            DevRepo content = GetDevById(id);

            if (content == null)
            {
                return false;
            }
            int initialCount = _listOfDev.Count;
            _listOfDev.Remove(content);
            if (initialCount > _listOfDev.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //helper
        private DevRepo GetDevById(short id)
        {
            foreach (DevRepo content in _listOfDev)
            {
                if (content.ID == id)
                {
                    return content;
                }
            }
            return null;
        }

    }
}

