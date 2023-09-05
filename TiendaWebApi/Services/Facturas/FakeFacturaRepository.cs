using TiendaWebApi.Models;


namespace TiendaWebApi.Services.FacturaRepository
{
    public class FakeFacturaRepository : IFacturaRepository
    {
        private readonly List<Factura> _facturaList = new();
        public FakeFacturaRepository()
        {
            _facturaList.Add(new Factura() 
            {
                Id = 1,
                NombreFactura = "Factura A",
                Precio = 0,
                Calor = 0,
                PedidoFactura = new PedidoFactura[]
                { 
                    new PedidoFactura()
                    {
                        Pedido = new Pedido
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

                        }

                    }

                }


            });
        }

        public void ActualizarFactura(int id, Factura factura)
        {
            var facturaEdit = _facturaList.Find(x => x.Id == id);
            if (facturaEdit != null)
            {
                facturaEdit.PedidoFactura = factura.PedidoFactura;
                facturaEdit.NombreFactura = factura.NombreFactura;
                facturaEdit.Calor = factura.Calor;
                facturaEdit.Precio = factura.Precio;
            }
        }

        public void AddDFactura(Factura factura)
        {
            _facturaList.Add(factura);
        }

        public void BorrarFactura(int id)
        {
            _facturaList.RemoveAt(id);
        }

        public double CalorTotal(int id)
        {
            double calor = 0;
            var factura = _facturaList.Find(x => x.Id == id);
            calor = factura!.PedidoFactura!.Select(x => x.Pedido)!.SelectMany(a => a.OrdenadoresAgregados!)
                .SelectMany(x => x.ComponentesAgregados!).Select(c => c.Calor).Sum();
            return calor;
        }

        public Factura? DameFactura(int id)
        {
            var factura = _facturaList.Find(x => x.Id == id);
            if (factura!.PedidoFactura != null)
            {
                factura.Calor = CalorTotal(id);
                factura.Precio = PrecioTotal(id);
            }
            return factura;
        }

        public IEnumerable<Factura> ListaFacturas()
        {
            _facturaList.ForEach(x=>DameFactura(x.Id));
            return _facturaList;
        }

        public double PrecioTotal(int id)
        {
            double precio = 0;
            var factura = _facturaList.Find(x => x.Id == id);
            precio = factura!.PedidoFactura!.Select(x=>x.Pedido)!.SelectMany(a=>a.OrdenadoresAgregados!)
                .SelectMany(x => x.ComponentesAgregados!).Select(c => c.Precio).Sum();
            return precio;
        }
    }
}
