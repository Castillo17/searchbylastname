using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_and_Address
{
    class Person : List<Address>
    {
        public List<Address> GetRegistrations(States searchStateUS)
        {
            List<Address> selectedStates = new List<Address>();
            foreach (var state in this)
            {
                if (state.StateUS == searchStateUS)
                {
                    selectedStates.Add(state);
                }
            }
            return selectedStates;
        }

        public List<Address> GetRegistrations(String lastName)
        {
            List<Address> selectedNames = new List<Address>();
            foreach (var name in this)
            {
                if (name.LastName == lastName)
                {
                    selectedNames.Add(name);
                }
            }

            return selectedNames;
        }
    }
}
