using System;

namespace Caissa.Classes
{
    public class Source
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

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private string _external_link;

        public string ExternalLink
        {
            get { return _external_link; }
            set { _external_link = value; }
        }

        private bool _is_active;

        public bool IsActive
        {
            get { return _is_active; }
            set { _is_active = value; }
        }

        private int _source_type;

        public int SourceType
        {
            get { return _source_type; }
            set { _source_type = value; }
        }

    }
}