using System;

namespace Caissa.Classes
{
    public class AssessmentItem
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _initials;

        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
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

        private string _expected_result;

        public string ExpectedResult
        {
            get { return _expected_result; }
            set { _expected_result = value; }
        }

        private string _procedure;

        public string Procedure
        {
            get { return _procedure; }
            set { _procedure = value; }
        }

        private double _div_dm;

        public double DivDM
        {
            get { return _div_dm; }
            set { _div_dm = value; }
        }

        private double _div_pp;

        public double DivPP
        {
            get { return _div_pp; }
            set { _div_pp = value; }
        }

        private double _cov_loc;

        public double CovLoc
        {
            get { return _cov_loc; }
            set { _cov_loc = value; }
        }

        private bool _is_active;

        public bool IsActive
        {
            get { return _is_active; }
            set { _is_active = value; }
        }

        private int _source;

        public int Source
        {
            get { return _source; }
            set { _source = value; }
        }
    }
}