using System;

namespace Caissa.Classes
{
    public class SystemUnderTest
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

        private bool _is_active;

        public bool IsActive
        {
            get { return _is_active; }
            set { _is_active = value; }
        }

    }
}