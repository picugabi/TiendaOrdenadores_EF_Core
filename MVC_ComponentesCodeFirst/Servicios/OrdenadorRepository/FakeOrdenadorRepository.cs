using MVC_ComponentesCodeFirst.Models;
using System.Drawing;
using TiendaOrdenadoresA.Comportamientos;

namespace MVC_ComponentesCodeFirst.Servicios.OrdenadorRepository
{
    public class FakeOrdenadorRepository : IOrdenadorRepository
    {
        private readonly List<Ordenador> _ordenadorList = new();
        public FakeOrdenadorRepository()
        {
            _ordenadorList.Add(new Ordenador
            {
                Id = 1,
                Calor = 0,
                Precio = 0,
                PedidoId = 1,
                NombreOrdenador = "Ordenador Paco",
                ComponentesAgregados = new Componente[]
                {
                    new Componente() 
                    { 
                        Id = 1,
                        NumeroDeSerie = "789_XCS",
                        Precio = 134,
                        Almacenamiento = 0,
                        Calor = 10,
                        Cores = 9,
                        TipoComponente = EnumTipoComponente.Procesador,
                        OrdenadorId =1
                        
                    },
                    new Componente() 
                    {
                        Id = 2,
                        NumeroDeSerie = "879FH",
                        Precio = 100,
                        Almacenamiento = 512,
                        Calor = 10,
                        Cores = 0,
                        TipoComponente = EnumTipoComponente.MemoriaRAM ,
                        OrdenadorId =1
                    },
                    new Componente() 
                    { Id = 3,
                        NumeroDeSerie = "789_XX_2",
                        Precio = 90,
                        Almacenamiento = 1000000,
                        Calor = 29,
                        Cores = 0,
                        TipoComponente = EnumTipoComponente.Almacenamiento,
                        OrdenadorId =1
                    }
                }
            });
            _ordenadorList.Add(new Ordenador
            {
                Id = 2,
                Calor = 0,
                Precio = 0,
                PedidoId=1,
                NombreOrdenador = "Ordenador Jose",
                ComponentesAgregados = new Componente[]
                {
                    new Componente()
                    {
                        Id = 4,
                        NumeroDeSerie = "789_XCD",
                        Precio = 138,
                        Almacenamiento = 0,
                        Calor = 12,
                        Cores = 10,
                        TipoComponente = EnumTipoComponente.Procesador,
                        OrdenadorId = 2
                    },
                    new Componente()
                    {
                        Id = 5,
                        NumeroDeSerie = "879FH",
                        Precio = 100,
                        Almacenamiento = 512,
                        Calor = 10,
                        Cores = 0,
                        TipoComponente = EnumTipoComponente.MemoriaRAM,
                        OrdenadorId = 2
                    },
                    new Componente()
                    {
                        Id = 6,
                        NumeroDeSerie = "789_XX",
                        Precio = 50,
                        Almacenamiento = 500000,
                        Calor = 10,
                        Cores = 0,
                        TipoComponente = EnumTipoComponente.Almacenamiento,
                        OrdenadorId = 2
                    }
                }
            });
        }
        public void ActualizarOrdenador(int id, Ordenador ordenador)
        {
            var ordenadorEdit = _ordenadorList.Find(x=>x.Id == id);
            ordenadorEdit.NombreOrdenador = ordenador.NombreOrdenador;
            ordenadorEdit.PedidoId = ordenador.PedidoId;
            ordenadorEdit.Calor = ordenador.Calor;
            ordenadorEdit.Precio = ordenador.Precio;
            ordenadorEdit.ComponentesAgregados = ordenador.ComponentesAgregados;
        }

        public void AddOrdenador(Ordenador ordenador)
        {
             _ordenadorList.Add(ordenador);
        }

        public void BorrarOrdenador(int id)
        {
            _ordenadorList.RemoveAt(id);
        }

        public double CalorTotal(int id)
        {
            double calor = 0;
            var ordenador = _ordenadorList.Find(x=>x.Id ==id);
            calor = ordenador!.ComponentesAgregados!.Sum(x=>x.Calor);
            return calor;
            
        }

        public Ordenador? DameOrdenador(int id)
        {
            var ordenador = _ordenadorList.Find(x => x.Id == id); 
            if (ordenador!.ComponentesAgregados != null)
            {
                ordenador.Calor = CalorTotal(ordenador.Id);
                ordenador.Precio = PrecioTotal(ordenador.Id);
            }
            return ordenador;
        }

        public IEnumerable<Ordenador> ListaOrdenadores()
        {
            _ordenadorList.ForEach(x => DameOrdenador(x.Id));
            return _ordenadorList.ToList();
        }

        public double PrecioTotal(int id)
        {
            double precio = 0;
            var ordenador = _ordenadorList.Find(x => x.Id == id);
            precio = ordenador!.ComponentesAgregados!.Sum(x => x.Precio);
            return precio;
        }
    }
}
