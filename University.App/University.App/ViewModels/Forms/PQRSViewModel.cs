using System.Collections.Generic;

namespace University.App.ViewModels.Forms
{
    public class PQRSViewModel : BaseViewModel
    {
        #region Attributes
        public class TypeRequest
        {
            public string Name { get; set; }
        }
        private List<TypeRequest> _typeRequests;
        #endregion

        #region Properties
        public List<TypeRequest> TypeRequests
        {
            get { return this._typeRequests; }
            set { this.SetValue(ref this._typeRequests, value); }
        }
        #endregion

        #region Constructor
        public PQRSViewModel()
        {
            this.LoadTypeRequests();
        }
        #endregion

        #region Methods
        private void LoadTypeRequests()
        {
            this.TypeRequests = new List<TypeRequest>
            {
                new TypeRequest { Name = "Name" },
                new TypeRequest { Name = "Surname" },
                new TypeRequest { Name = "Direction" },
                new TypeRequest { Name = "Phone" },
                new TypeRequest { Name = "E-mail" },
                new TypeRequest { Name = "Message" },
                new TypeRequest { Name = "Rate Our Service (Bad-Regular-Well-Acceptable-Excellent)" },
            };
        }
        #endregion
    }
}