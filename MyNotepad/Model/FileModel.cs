using System;

namespace MyNotepad.DataLayer
{
    public class File
    {
        private byte[] _data;

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data
        {
            get { return _data;}
            set
            {
                _data = value;
                LastChangeDate = DateTime.Now.ToString();
            }
        }
        public string LastChangeDate { get; protected set; }
        public string Format { get; set; }
    }
}