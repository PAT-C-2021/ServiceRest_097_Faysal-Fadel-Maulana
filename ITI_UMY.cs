using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace ServiceRest_097_Faysal_Fadel_Maulana
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITI_UMY
    {
        [OperationContract]
        [WebGet(UriTemplate = "Mahasiswa", ResponseFormat = WebMessageFormat.Json)]
        List<Mahasiswa> GetAllMahasiswa();

        [OperationContract]
        [WebGet(UriTemplate = "Mahasiswa/nim={nim}", ResponseFormat = WebMessageFormat.Json)]
        Mahasiswa GetMahasiswaByNIM(string nim);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mahasiswa", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string CreateMahasiswa(Mahasiswa mhs);

        /*[OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);*/

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceRest_097_Faysal_Fadel_Maulana.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class Mahasiswa
    {
        private string _nim, _nama, _prodi, _angkatan;
        
        [DataMember(Order = 1)]
        public string nim
        {
            get { return _nim; }
            set { _nim = value; }
        }

        [DataMember(Order = 2)]
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }

        [DataMember(Order = 3)]
        public string prodi
        {
            get { return _prodi; }
            set { _prodi = value; }
        }
        [DataMember(Order = 4)]
        public string angkatan
        {
            get { return _angkatan; }
            set { _angkatan = value; }
        }
    }
}
