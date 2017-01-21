using System;

namespace Caissa.Classes
{
    public class Test
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _view_title;

        public string ViewTitle
        {
            get { return _view_title; }
            set { _view_title = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private DateTime _initial_date;

        public DateTime InitialDate
        {
            get { return _initial_date; }
            set { _initial_date = value; }
        }

        private DateTime _finish_date;

        public DateTime FinishDate
        {
            get { return _finish_date; }
            set { _finish_date = value; }
        }

        private bool _is_active;

        public bool IsActive
        {
            get { return _is_active; }
            set { _is_active = value; }
        }

        private int _system;

        public int System
        {
            get { return _system; }
            set { _system = value; }
        }
    }
}