using TiendaWebApi.Models;

namespace TiendaWebApi.Services.PedidoRepository
{
    public class FakePedidoRepository : IPedidoRepository
    {
        private readonly List<Pedido> _pedidoList = new();
        public FakePedidoRepository() 
        {
            _pedidoList.Add(new Pedido 
            { 
                Id = 1,
                Calor = 0,
                Precio = 0,
                NombrePedido = "Pedido A",
                OrdenadoresAgregados = new Ordenador[]
                {
                    new Ordenador()
                    {
                        Id = 1,
                        Calor = 0,
                        Precio = 0,
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
                    },
                    new Ordenador
                    {
                        Id = 2,
                        Calor = 0,
                        Precio = 0,
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
                    }
                }


            });

        }

        public void ActualizarPedido(int id, Pedido pedido)
        {
            var pedidoEdit = _pedidoList.Find(x => x.Id == id);
            pedidoEdit!.NombrePedido = pedido.NombrePedido;
            pedidoEdit.Calor = pedido.Calor;
            pedidoEdit.Precio = pedido.Precio;
            pedidoEdit.OrdenadoresAgregados = pedido.OrdenadoresAgregados;
        }

        public void AddPedido(Pedido pedido)
        {
            _pedidoList.Add(pedido);
        }

        public void BorrarPedido(int id)
        {
            _pedidoList.RemoveAt(id);
        }

        public double CalorTotal(int id)
        {
            double calor = 0;
            var pedido = _pedidoList.Find(x => x.Id == id);
            calor = pedido.OrdenadoresAgregados!.SelectMany(x => x.ComponentesAgregados!).Select(c=>c.Calor).Sum();
            return calor;
        }

        public Pedido? DamePedido(int id)
        {
            var pedido = _pedidoList.Find(x => x.Id == id);
            if (pedido!.OrdenadoresAgregados != null)
            {
                pedido.Calor = CalorTotal(pedido.Id);
                pedido.Precio = PrecioTotal(pedido.Id);
            }
            return pedido;
        }

        public IEnumerable<Pedido> ListaPedidos()
        {
            _pedidoList.ForEach(x => DamePedido(x.Id));
            return _pedidoList.ToList();
        }

        public double PrecioTotal(int id)
        {
            double precio = 0;
            var pedido = _pedidoList.Find(x => x.Id == id);
            precio = pedido!.OrdenadoresAgregados!.SelectMany(x => x.ComponentesAgregados!).Select(c => c.Precio).Sum();
            return precio;
        }
    }
}
