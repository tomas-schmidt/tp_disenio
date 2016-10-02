using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.SqlClient;
using tp_disenio_1.Reportes;
using System.Data;
using System.Data.SqlClient;

namespace tp_disenio_1
{
    class CatalogoPois
    {
        protected List<Poi> pois = new List<Poi>();
        //private static CatalogoPois instance;

        //private CatalogoPois()
        //{
            
        //}

        //public static CatalogoPois Instance()
        //{
        //    if (instance == null)
        //    {
        //        instance = new CatalogoPois();
        //    }
        //    return instance;
        //}

        public void agregarPoi(Poi poiNuevo)
        {
           pois.Add(poiNuevo);
        }

        public void eliminarPoi(Poi poiNuevo)
        {
            pois.Remove(poiNuevo);
        }


        public List<Poi> lista()
        {
            return this.pois;
        }


        
       
        public List<Poi> buscar(String texto)
        {
            
            List<Poi> resultado = new List<Poi>();
            foreach (Poi poi in pois)
            {
                if (poi.matcheaBusqueda(texto))
                {
                    resultado.Add(poi);
                }
            }                            

            return resultado;
        }


        public bool tieneA(string nombre)
        {
            foreach (Poi poi in pois)
            {
                if (poi.obtenerNombre() == nombre)
                {
                    return true;
                }
            }
            return false;
        }

        public Poi obtenerPoi(string nombre)
        {
            Poi poi;
            poi =pois.Find(p => p.obtenerNombre() == nombre);
            return poi;
        }

        public List<Poi> poiss()
        {
            List<Poi> pois = new List<Poi>();

            HorarioDeAtencion lunesAVierner9a18;
            lunesAVierner9a18 = new HorarioDeAtencion(new Tuple<int, int>[]{
                new Tuple<int,int>(0,0),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(9,18),
                new Tuple<int,int>(0,0),
            });

            BaseDeDatos bd = new BaseDeDatos();
            var spObtenerParadas = bd.obtenerStoredProcedure("obtenerParadas");
            var spObtenerLocales = bd.obtenerStoredProcedure("obtenerLocales");
            var spObtenerRubrosDeLocal = bd.obtenerStoredProcedure("obtenerRubrosDeLocal");
            var spObtenerCgps = bd.obtenerStoredProcedure("obtenerCgps");
            var spObtenerServiciosDeCgp = bd.obtenerStoredProcedure("obtenerServiciosDeCgp");
            var spObtenerBancos = bd.obtenerStoredProcedure("obtenerBancos");
            var spObtenerHorariosPoi = bd.obtenerStoredProcedure("obtenerHorariosPoi");



            //PARADAS
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = spObtenerParadas;
            DataTable dbdataset = new DataTable();
            sda.Fill(dbdataset);
            foreach (DataRow item in dbdataset.Rows)
            {
                Tuple<int, int>[] matrizHorarios;
                matrizHorarios = new Tuple<int, int>[7];

                /*spObtenerHorariosPoi.Parameters.Add("@id_poi", SqlDbType.Int).Value = Convert.ToInt32(item["id_poi"]);
                sda.SelectCommand = spObtenerRubrosDeLocal;
                DataTable dbdataset6 = new DataTable();
                sda.Fill(dbdataset6);
                foreach (DataRow item6 in dbdataset6.Rows)
                {
                    matrizHorarios.Aggregate<Tuple<(Convert.ToInt32(item["id_poi"]), (Convert.ToInt32(item["id_poi"])>;
                }*/
                Parada parada;
                parada = new Parada(Convert.ToDouble(item["latitud"]), Convert.ToDouble(item["longitud"]), item["nombre"].ToString(), item["direccion"].ToString(), lunesAVierner9a18, item["numero"].ToString());
                pois.Add(parada);     
            }

            //LOCALES
            sda.SelectCommand = spObtenerParadas;
            DataTable dbdataset2 = new DataTable();
            sda.Fill(dbdataset2);
            foreach (DataRow item in dbdataset2.Rows)
            {
                HashSet<string> rubros = new HashSet<string>();
                spObtenerRubrosDeLocal.Parameters.Add("@id_local", SqlDbType.Int).Value = Convert.ToInt32(item["id_local"]);
                sda.SelectCommand = spObtenerRubrosDeLocal;
                DataTable dbdataset3 = new DataTable();
                sda.Fill(dbdataset3);
                foreach (DataRow item3 in dbdataset3.Rows)
                {
                    string rubro = item3["descripcion"].ToString();
                    rubros.Add(rubro);
                }
                Local local;
                local = new Local(Convert.ToDouble(item["latitud"]), Convert.ToDouble(item["longitud"]), item["nombre"].ToString(), item["direccion"].ToString(), lunesAVierner9a18, rubros, Convert.ToInt32(item["radio_cercania"]));

                pois.Add(local);
            }

            //CGPS
            sda.SelectCommand = spObtenerCgps;
            DataTable dbdataset4 = new DataTable();
            sda.Fill(dbdataset4);
            foreach (DataRow item in dbdataset4.Rows)
            {
                List<Servicio> listaServicios = new List<Servicio>();
                spObtenerServiciosDeCgp.Parameters.Add("@id_cgp", SqlDbType.Int).Value = Convert.ToInt32(item["id_cgp"]);
                sda.SelectCommand = spObtenerServiciosDeCgp;
                DataTable dbdataset3 = new DataTable();
                sda.Fill(dbdataset3);
                foreach (DataRow item3 in dbdataset3.Rows)
                {
                    Servicio unServicio;
                    unServicio = new Servicio(item["descripcion"].ToString(), lunesAVierner9a18);
                }
                CGP cgp;
                cgp = new CGP(Convert.ToDouble(item["latitud"]), Convert.ToDouble(item["longitud"]), item["nombre"].ToString(), item["direccion"].ToString(), lunesAVierner9a18, Convert.ToInt32(item["comuna"]), listaServicios);

                pois.Add(cgp);
            }

            //BANCOS
            sda.SelectCommand = spObtenerBancos;
            DataTable dbdataset5 = new DataTable();
            sda.Fill(dbdataset5);
            foreach (DataRow item in dbdataset5.Rows)
            {
                Banco banco;
                banco = new Banco(Convert.ToDouble(item["latitud"]), Convert.ToDouble(item["longitud"]), item["nombre"].ToString(), item["direccion"].ToString(), lunesAVierner9a18);
                pois.Add(banco);
            }

            return pois;
        }

    }
}
