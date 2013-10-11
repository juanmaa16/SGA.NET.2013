using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            this.State = States.New;
        }

        private int _id;
        private States _state;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public States State
        {
            get { return _state; }
            set { _state = value; }
        }

        public enum States
        {
            Deleted,
            New,
            Modified,
            Unmodified
        }

    }
}
