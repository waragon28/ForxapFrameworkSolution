using RestSharp;
using System;

using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using Forxap.Framework.ServiceLayer;
using ServiceLayerTest;
using Newtonsoft.Json.Linq;

namespace ServiceLayerTest
{
    public partial class frmUDT : Form
    {
        bool isSuccess = false;
        string ErrorCode = string.Empty;
        string ErrorMessage = string.Empty;

        string objectName = string.Empty;
        string filter = string.Empty;
        string key = string.Empty;

        
        public frmUDT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show("Iniciando proceso.....");

        //    Globals.CompanyName = "CSATEMP";// CompanyName;
        //    Globals.UserName = "manager"; //UserName;

       //     Globals.UserPassword = "Qw3rty@7";//UserPassword;
       //     Globals.UrlServiceLayer = "https://csasbo2.construlandia.com:50000/b1s/v1/"; //UrlServiceLayer;


    //        MessageBox.Show("Compñaia :" + Globals.CompanyName);
      //      MessageBox.Show("Sociedad : " +  Globals.CompanyName.ToString());


            Forxap.Framework.ServiceLayer.Connection conection = new Forxap.Framework.ServiceLayer.Connection();
            IRestResponse response;

            response = conection.Connect();

            if (response.StatusCode.ToString() == "OK")
            {
                textBox1.Text += "Conectado" + "\r\n";

                textBox1.Text += Forxap.Framework.ServiceLayer.Globals.SessionId + "\r\n";
                textBox1.Text += response.StatusCode.ToString() + "\r\n";
                textBox1.Text += response.ResponseStatus.ToString() + "\r\n";

            }

            else
            {
                textBox1.Text += "Error al Conectar" + "\r\n";

                textBox1.Text += response.StatusCode.ToString() + "\r\n";
                if (!string.IsNullOrEmpty(response.StatusDescription))
                    {
                    textBox1.Text += response.StatusDescription.ToString() + "\r\n";
                }
                    textBox1.Text += response.ResponseStatus.ToString() + "\r\n";
                

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            isSuccess = false;

            if (Forxap.Framework.ServiceLayer.Globals.IsConnected)

                isSuccess = true; //Forxap.Framework.ServiceLayer.Connection .FrameWork.ServiceLayer.Disconnect();
            else
            {
                MessageBox.Show("no se encuentra conectado");
            }

            if (isSuccess)
                textBox1.Text = textBox1.Text + "Desconectado" + "\r\n";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            /// obtengo todos los registros de la tabla de usuario "U_NXPOS", que se encuentren en estado 1  
            // dynamic query = Forxap.FrameWork.ServiceLayer.GET("U_NXPOS?$filter=U_NXSTATUS eq 1", "");
            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            objectName = txtObject.Text.Trim();

            string ErrorCode = string.Empty;
            string ErrorMessage = string.Empty;

            IRestResponse query =  methods.GET(  objectName,"");

            textBox1.Text = query.Content.ToString();

            //if (query["error"] != null)
            //{
            //    ErrorCode = query["error"]["code"].ToString();
            //    ErrorMessage = query["error"]["message"]["value"].ToString();
            //}

            //string codeError = string.Empty;
            //string code = string.Empty;
            //string name = string.Empty;
            //string shortName = string.Empty;


            //// si quieren traer un listao de registros ya sea con filtros o sin fi
            //if (query["value"] != null)
            //{
            //    foreach (var item in query["value"])
            //    {
            //        if (item["Code"] != null)
            //        code = "'" + item["Code"].ToString() + "'";

            //        if (item["Name"] != null )
            //        name = item["Name"].ToString();
                    
            //        if (item["U_ShortName"] != null )
            //        shortName = item["U_ShortName"].ToString();

            //        textBox1.Text += "Código : " + code + "\r\n";
            //        textBox1.Text += "Nombre : " + name + "\r\n";
            //        textBox1.Text += "Nombre Abreviado : " + shortName + "\r\n";

            //    }


            //}
            //else
            //{
            //    // si solo quieren traer un solo registro a travez del ID
            //    code = "'" + query["Code"].ToString() + "'";
            //    name = query["Name"].ToString();
            //    shortName = query["U_ShortName"].ToString();

            //    textBox1.Text += "Código : " + code + "\r\n";
            //    textBox1.Text += "Nombre : " + name + "\r\n";
            //    textBox1.Text += "Nombre Abreviado : " + shortName + "\r\n";
                
            //}


        }

        private void button4_Click(object sender, EventArgs e)
        {
            //        Forxap.FrameWork.ServiceLayer.POST("", "");

            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();





            IRestResponse respta2 = methods.PATCH("VIST_COBRANZA", "2", textBox10.Text);

            textBox1.Text = respta2.ContentType.ToString();
        }


        public class TablaUsuario 
        {
            public string Code { get; set; }
            public string Name { get; set; }

            public string U_ShortName { get; set; }
            public TablaUsuario()
            {

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            TablaUsuario tblUser = new TablaUsuario();

            tblUser.Code = textBox2.Text;
            tblUser.Name = textBox3.Text;
            tblUser.U_ShortName = textBox4.Text;

            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            methods.POST("https://10.177.10.187:50000/b1s/v1/Orders","");

      //    dynamic respta2 = Forxap.FrameWork.ServiceLayer.POST("U_FXP_HR_SU08", JsonConvert.SerializeObject(tblUser));
            
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
        /////    dynamic respta2 = Forxap.FrameWork.ServiceLayer.DELETE("U_FXP_HR_SU08","'22'");
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {


                string key = string.Empty;
                string ErrorCode = string.Empty;
                string ErrorMessage = string.Empty;

                key =txtID.Text.Trim() ; // leo el ID que quieren buscar

            ///////   dynamic query = Forxap.FrameWork.ServiceLayer.GET("U_FXP_HR_SU08", key);

            textBox1.Clear();
            /// obtengo todos los registros de la tabla de usuario "U_NXPOS", que se encuentren en estado 1  
            // dynamic query = Forxap.FrameWork.ServiceLayer.GET("U_NXPOS?$filter=U_NXSTATUS eq 1", "");
            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            objectName = txtObject.Text.Trim();

            

            dynamic query = methods.GET(objectName, key);



            if (query["error"] != null)
            {
                ErrorCode = query["error"]["code"].ToString();
                ErrorMessage = query["error"]["message"]["value"].ToString();
            }

            string codeError = string.Empty;
            string code = string.Empty;
            string name = string.Empty;
            string shortName = string.Empty;


            // si quieren traer un listao de registros ya sea con filtros o sin fi
            if (query["value"] != null)
            {
                foreach (var item in query["value"])
                {
                    code = "'" + item["Code"].ToString() + "'";
                    name = item["Name"].ToString();
                    shortName = item["U_ShortName"].ToString();

                    textBox1.Text += "Código : " + code + "\r\n";
                    textBox1.Text += "Nombre : " + name + "\r\n";
                    textBox1.Text += "Nombre Abreviado : " + shortName + "\r\n";

                }


            }
            else
            {
                // si solo quieren traer un solo registro a travez del ID
                code = "'" + query["Code"].ToString() + "'";
                name = query["Name"].ToString();
                shortName = query["U_ShortName"].ToString();

                textBox1.Text += "Código : " + code + "\r\n";
                textBox1.Text += "Nombre : " + name + "\r\n";
                textBox1.Text += "Nombre Abreviado : " + shortName + "\r\n";

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //textBox1.Clear();


            //tableName = textBox8.Text.Trim();
            //key =    string.Format("'{0}'", textBox5.Text.Trim());
            //filter = string.Format("{0}", textBox6.Text.Trim() );

            //dynamic query = Forxap.FrameWork.ServiceLayer.GET(tableName, key, filter);


            //if (query["error"] != null)
            //{
            //    ErrorCode = query["error"]["code"].ToString();
            //    ErrorMessage = query["error"]["message"]["value"].ToString();
            //}

            //string codeError = string.Empty;
            //string code = string.Empty;
            //string name = string.Empty;
            //string shortName = string.Empty;


            //// si quieren traer un listao de registros ya sea con filtros o sin fi
            //if (query["value"] != null)
            //{
            //    foreach (var item in query["value"])
            //    {
            //        code = "'" + item["Code"].ToString() + "'";
            //        name = item["Name"].ToString();
            //        shortName = item["U_ShortName"].ToString();

            //        textBox1.Text += "Código : " + code + "\r\n";
            //        textBox1.Text += "Nombre : " + name + "\r\n";
            //        textBox1.Text += "Nombre Abreviado : " + shortName + "\r\n";

            //    }


            //}
            //else
            //{
            //    // si solo quieren traer un solo registro a travez del ID

            //    if (query["Code"] != null)
            //    code = "'" + query["Code"].ToString() + "'";
            //    if (query["Name"] != null)
            //    name = query["Name"].ToString();
                

            //    textBox1.Text += "Código : " + code + "\r\n";
            //    textBox1.Text += "Nombre : " + name + "\r\n";
         

            //}
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //textBox1.Clear();

            //Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            //tableName = textBox8.Text.Trim();
            //key = string.Format("'{0}'", textBox5.Text.Trim());
            //filter = string.Format("{0}", textBox7.Text.Trim());

            //dynamic query = methods.GET(tableName, key, filter);


            //if (query["error"] != null)
            //{
            //    ErrorCode = query["error"]["code"].ToString();
            //    ErrorMessage = query["error"]["message"]["value"].ToString();
            //}

            //string codeError = string.Empty;
            //string code = string.Empty;
            //string name = string.Empty;
            //string shortName = string.Empty;


            //// si quieren traer un listao de registros ya sea con filtros o sin fi
            //if (query["value"] != null)
            //{
            //    foreach (var item in query["value"])
            //    {
            //        code = "'" + item["Code"].ToString() + "'";
            //        name = item["Name"].ToString();
            //        shortName = item["U_ShortName"].ToString();

            //        textBox1.Text += "Código : " + code + "\r\n";
            //        textBox1.Text += "Nombre : " + name + "\r\n";
            //        textBox1.Text += "Nombre Abreviado : " + shortName + "\r\n";

            //    }


            //}
            //else
            //{
            //    // si solo quieren traer un solo registro a travez del ID

            //    if (query["Code"] != null)
            //        code = "'" + query["Code"].ToString() + "'";
            //    if (query["Name"] != null)
            //        name = query["Name"].ToString();


            //    textBox1.Text += "Código : " + code + "\r\n";
            //    textBox1.Text += "Nombre : " + name + "\r\n";


           // }
        }

        private void button10_Click(object sender, EventArgs e)
        {


         
            

            IRestResponse response;
            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            response = methods.POST("Orders", textBox9.Text);

            textBox1.Text = string.Empty;

            if (response.StatusCode.ToString() == "Created")
            {
                textBox1.Text += response.StatusCode.ToString() + "\r\n";
                textBox1.Text += response.StatusDescription.ToString() + "\r\n";

                textBox1.Text += response.Content.ToString() + "\r\n";

            }

            else
            {
                
                textBox1.Text += response.Content.ToString() + "\r\n";

            }


        }



        private void button11_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://10.177.10.187:50000/b1s/v1/Orders");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/plain");
            var body = @"{
" + "\n" +
            @"
" + "\n" +
            @"""CardCode"":""C10093493546"",
" + "\n" +
            @"""Comments"":""domingo 15"",
" + "\n" +
            @"""DocCurrency"":""S/"",
" + "\n" +
            @"""DocDate"": ""20210811"",
" + "\n" +
            @"""DocDueDate"": ""20210811"",
" + "\n" +
            @"""DocRate"":""1"",
" + "\n" +
            @"""DocType"":""I"",
" + "\n" +
            @"""DocumentsOwner"":""178"",
" + "\n" +
            @"""FederalTaxID"":""10093493546"",
" + "\n" +
            @"""DocumentLines"":[{""AcctCode"":"""",""COGSAccountCode"":"""",""CostingCode"":""U111"",""CostingCode2"":""U1111"",""CostingCode3"":""PR99"",""DiscountPercent"":""0"",""Dscription"":""CIL H-3 PARA RODAMIENTOS NEGRA DE 400 LIBRAS"",""ItemCode"":""1100013"",""LineTotal"":""1771.20"",""Price"":""1771.2"",""Quantity"":""1"",""TaxCode"":""IGV"",""TaxOnly"":""N"",""U_SYP_FECAT07"":""10"",""U_VIST_CTAINGDCTO"":"""",""U_VIS_PromID"":""0"",""U_VIS_PromLineID"":""0"",""WarehouseCode"":""AN001""}],""PayToCode"":""01"",""PaymentGroupCode"":""-1"",""SalesPersonCode"":""150"",""ShipToCode"":""01"",""TaxDate"":""20210809"",""U_SYP_DOCEXPORT"":""N"",""U_SYP_FEEST"":""PE"",""U_SYP_FEMEX"":""1"",""U_SYP_FETO"":""01"",""U_SYP_MDCD"":"""",""U_SYP_MDCT"":"""",""U_SYP_MDMT"":""01"",""U_SYP_MDSD"":"""",""U_SYP_MDTD"":"""",""U_SYP_STATUS"":""V"",""U_SYP_TVENTA"":""01"",""U_SYP_VIST_TG"":""N"",""U_VIST_SUCUSU"":""ANCON"",""U_VIS_AgencyCode"":"""",""U_VIS_AgencyDir"":"""",""U_VIS_AgencyName"":"""",""U_VIS_AgencyRUC"":"""",""U_VIS_CompleteOV"":""N"",""U_VIS_ENCommentary"":"""",""U_VIS_INCommentary"":"""",""U_VIS_OVCommentary"":""prueba"",""U_VIS_SalesOrderID"":""20210809114126""}";



            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        private void button12_Click(object sender, EventArgs e)
        {

            string slURL =               "https://10.177.10.187:50000/b1s/v1/";




            string JSonOrders = @"{
            " + "\n" +
            @"
            " + "\n" +
            @"""CardCode"":""C10093493546"",
            " + "\n" +
            @"""Comments"":""Domingo de noche"",
            " + "\n" +
            @"""DocCurrency"":""S/"",
            " + "\n" +
            @"""DocDate"": ""20210811"",
            " + "\n" +
            @"""DocDueDate"": ""20210811"",
            " + "\n" +
            @"""DocRate"":""1"",
            " + "\n" +
            @"""DocType"":""I"",
            " + "\n" +
            @"""DocumentsOwner"":""178"",
            " + "\n" +
            @"""FederalTaxID"":""10093493546"",
            " + "\n" +
            @"""DocumentLines"":[{""AcctCode"":"""",""COGSAccountCode"":"""",""CostingCode"":""U111"",""CostingCode2"":""U1111"",""CostingCode3"":""PR99"",""DiscountPercent"":""0"",""Dscription"":""CIL H-3 PARA RODAMIENTOS NEGRA DE 400 LIBRAS"",""ItemCode"":""1100013"",""LineTotal"":""1771.20"",""Price"":""1771.2"",""Quantity"":""1"",""TaxCode"":""IGV"",""TaxOnly"":""N"",""U_SYP_FECAT07"":""10"",""U_VIST_CTAINGDCTO"":"""",""U_VIS_PromID"":""0"",""U_VIS_PromLineID"":""0"",""WarehouseCode"":""AN001""}],""PayToCode"":""01"",""PaymentGroupCode"":""-1"",""SalesPersonCode"":""150"",""ShipToCode"":""01"",""TaxDate"":""20210809"",""U_SYP_DOCEXPORT"":""N"",""U_SYP_FEEST"":""PE"",""U_SYP_FEMEX"":""1"",""U_SYP_FETO"":""01"",""U_SYP_MDCD"":"""",""U_SYP_MDCT"":"""",""U_SYP_MDMT"":""01"",""U_SYP_MDSD"":"""",""U_SYP_MDTD"":"""",""U_SYP_STATUS"":""V"",""U_SYP_TVENTA"":""01"",""U_SYP_VIST_TG"":""N"",""U_VIST_SUCUSU"":""ANCON"",""U_VIS_AgencyCode"":"""",""U_VIS_AgencyDir"":"""",""U_VIS_AgencyName"":"""",""U_VIS_AgencyRUC"":"""",""U_VIS_CompleteOV"":""N"",""U_VIS_ENCommentary"":"""",""U_VIS_INCommentary"":"""",""U_VIS_OVCommentary"":""prueba"",""U_VIS_SalesOrderID"":""20210809114126""}";






            RestClient restClient = new RestClient(Forxap.Framework.ServiceLayer.Globals.UrlServiceLayer + "Orders");


            RestRequest restRequest = new RestRequest(Method.POST);
            restClient.Proxy = System.Net.WebRequest.GetSystemWebProxy();

            restRequest.AddHeader("Cache-Control", "no-cache");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("undefined", (object)JSonOrders, ParameterType.RequestBody);
            restRequest.AddCookie("B1SESSION",Forxap.Framework.ServiceLayer.Globals.SessionId);



            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            IRestResponse restResponse = restClient.Execute((IRestRequest)restRequest);
   

       //     MessageBox.Show(  restResponse.ErrorMessage.ToString());


        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            /// obtengo todos los registros de la tabla de usuario "U_NXPOS", que se encuentren en estado 1  
            // dynamic query = Forxap.FrameWork.ServiceLayer.GET("U_NXPOS?$filter=U_NXSTATUS eq 1", "");
            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            objectName = textBox5.Text.Trim();

            string ErrorCode = string.Empty;
            string ErrorMessage = string.Empty;

            IRestResponse query = methods.GET(objectName, "");

            textBox1.Text = query.Content.ToString();
            System.Data.DataTable dt = new DataTable();


         //   MessageBox.Show("Iniciando conversion a lista generica");
          //  List<SalesPerson> UserList = JsonConvert.DeserializeObject<List<SalesPerson>>(textBox1.Text);

            dt= Tabulate(textBox1.Text);
           // MessageBox.Show("Teminando conversion a lista generica");


            
            //dt = UserList.ToDataTable<SalesPerson>();

            dataGridView1.DataSource = dt;

            dataGridView1.Refresh();

        }


        public static DataTable Tabulate(string json)
        {
            var jsonLinq = JObject.Parse(json);

            // Find the first array using Linq
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }

                trgArray.Add(cleanRow);
            }

            return JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            /// obtengo todos los registros de la tabla de usuario "U_NXPOS", que se encuentren en estado 1  
            // dynamic query = Forxap.FrameWork.ServiceLayer.GET("U_NXPOS?$filter=U_NXSTATUS eq 1", "");
            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            objectName = textBox8.Text.Trim();

            string ErrorCode = string.Empty;
            string ErrorMessage = string.Empty;

            IRestResponse query = methods.GET(objectName, "");

            textBox1.Text = query.Content.ToString();
            System.Data.DataTable dt = new DataTable();


            //   MessageBox.Show("Iniciando conversion a lista generica");
            //  List<SalesPerson> UserList = JsonConvert.DeserializeObject<List<SalesPerson>>(textBox1.Text);

            dt = Tabulate(textBox1.Text);
            // MessageBox.Show("Teminando conversion a lista generica");



            //dt = UserList.ToDataTable<SalesPerson>();

            dataGridView2.DataSource = dt;

            dataGridView2.Refresh();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            /// obtengo todos los registros de la tabla de usuario "U_NXPOS", que se encuentren en estado 1  
            // dynamic query = Forxap.FrameWork.ServiceLayer.GET("U_NXPOS?$filter=U_NXSTATUS eq 1", "");
            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            objectName = textBox11.Text.Trim();

            string ErrorCode = string.Empty;
            string ErrorMessage = string.Empty;

            IRestResponse query = methods.GET(objectName, "");

            textBox1.Text = query.Content.ToString();
            System.Data.DataTable dt = new DataTable();


            //   MessageBox.Show("Iniciando conversion a lista generica");
            //  List<SalesPerson> UserList = JsonConvert.DeserializeObject<List<SalesPerson>>(textBox1.Text);

            dt = Tabulate(textBox1.Text);
            // MessageBox.Show("Teminando conversion a lista generica");



            //dt = UserList.ToDataTable<SalesPerson>();

            dataGridView3.DataSource = dt;

            dataGridView3.Refresh();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            /// obtengo todos los registros de la tabla de usuario "U_NXPOS", que se encuentren en estado 1  
            // dynamic query = Forxap.FrameWork.ServiceLayer.GET("U_NXPOS?$filter=U_NXSTATUS eq 1", "");
            Forxap.Framework.ServiceLayer.Methods methods = new Forxap.Framework.ServiceLayer.Methods();

            objectName = textBox12.Text.Trim();

            string ErrorCode = string.Empty;
            string ErrorMessage = string.Empty;

            IRestResponse query = methods.GET(objectName, "");

            textBox1.Text = query.Content.ToString();
            System.Data.DataTable dt = new DataTable();


            //   MessageBox.Show("Iniciando conversion a lista generica");
            //  List<SalesPerson> UserList = JsonConvert.DeserializeObject<List<SalesPerson>>(textBox1.Text);

            dt = Tabulate(textBox1.Text);
            // MessageBox.Show("Teminando conversion a lista generica");



            //dt = UserList.ToDataTable<SalesPerson>();

            dataGridView4.DataSource = dt;

            dataGridView4.Refresh();

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }
    }


    public class SalesPerson
    {
        private string salesEmployeeCode;
        private string salesEmployeeName;
        private string remarks;
        private string telephone;
        private string mobile;
        private string locked;
        private string _active;
        private string fax;
        private string email;
        private double commissionForSalesEmployee = 0.0;
        private int commissionGroup = 0;
        private string usuarioWeb;
        private string crearPedido = "N";
        private string crearGasto = "N";
        private string employeeID;
        private string autorizadorGasto;
        private string passWeb;
        private string crearNomina;
        //     private string centro;

        public SalesPerson()
        {

        }

        public string SalesEmployeeCode
        {
            get { return salesEmployeeCode; }
            set { salesEmployeeCode = value; }
        }

                      
        public string SalesEmployeeName
        {
            get { return salesEmployeeName; }
            set { salesEmployeeName = value; }
        }



        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }



        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }



        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }



        public string Locked
        {
            get { return "Percy"; }
            set { locked    = "Iker"; }
        }


        public string Active
        {
            get { return _active; }
            set { _active = value; }
        }


        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }



        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public double CommissionForSalesEmployee
        {
            get { return commissionForSalesEmployee; }
            set { commissionForSalesEmployee = value; }
        }



        public int CommissionGroup
        {
            get { return commissionGroup; }
            set { commissionGroup = value; }
        }



        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }



        public string U_UsuarioWeb
        {
            get { return usuarioWeb; }
            set { usuarioWeb = value; }
        }

        public string U_PassWeb
        {
            get { return passWeb; }
            set { passWeb = value; }
        }



        public string U_CrearPedido
        {
            get { return crearPedido; }
            set { crearPedido = value; }
        }


        public string U_CrearGasto
        {
            get { return crearGasto; }
            set { crearGasto = value; }
        }



        public string U_AutorizadorGasto
        {
            get { return autorizadorGasto; }
            set { autorizadorGasto = value; }
        }


        public string U_CrearNomina
        {
            get { return crearNomina; }
            set { crearNomina = value; }
        }

        public string U_Centro
        {
            get { return crearNomina; }
            set { crearNomina = value; }
        }






    }
}
