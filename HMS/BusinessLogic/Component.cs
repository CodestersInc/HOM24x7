﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Component : IModel
    {
        public int ComponentID;
        public String Name;
        public String Description;
        public String Image;
        public int AccountID;

        public Component()
        {

        }

        public Component(int ComponentID, String Name, String Description, String Image, int AccountID)
        {
            this.ComponentID = ComponentID;
            this.Name = Name;
            this.Description = Description;
            this.Image = Image;
            this.AccountID = AccountID;
        }
    }
}
