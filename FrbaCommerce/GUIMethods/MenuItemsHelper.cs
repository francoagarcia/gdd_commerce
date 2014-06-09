using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.GUIMethods
{
    public class MenuItemsHelper
    {
        public void manejarItems(ToolStripItemCollection menu_toolItems, IList<string> listaNombresCruda)
        {
            this.esconderLosQueNoEstenEnLaLista(menu_toolItems, listaNombresCruda);
            this.mostrarAquellosQueTieneTodosSusHijosHabilitados(menu_toolItems);
            int cant = 0;
            while (cant <= this.cantidadMaximaDeSubNiveles(menu_toolItems))
            {
                this.mostrarAquellosQueTieneTodosSusHijosHabilitados(menu_toolItems);
                cant++;
            }
        }

        public void esconderLosQueNoEstenEnLaLista(ToolStripItemCollection menu_toolItems, IList<string> listaNombresCruda)
        {
            List<ToolStripMenuItem> allMenuStripItems = this.getAllItems(menu_toolItems);
            IList<string> listaNombresCocinada = adaptarListaDeFuncionalidades(listaNombresCruda);
            foreach (ToolStripMenuItem item in allMenuStripItems)
            {
                if (hayQueHabilitarFuncionalidad(item, listaNombresCocinada))
                {
                    item.Enabled = item.Visible = true;
                }
                else
                {
                    item.Enabled = item.Visible = false;
                }
            }
        }

        private  bool hayQueHabilitarFuncionalidad(ToolStripMenuItem item, IList<string> listaNombresCocinada)
        {                                                                                                                          //itm_Var_
            return (this.isItemConst(item.Name) || (this.isItemVar(item.Name) && listaNombresCocinada.Contains(item.Name.Substring(8))));
        }

        private  IList<string> adaptarListaDeFuncionalidades(IList<string> funcStringDB)
        {
            IList<string> funcionalidadesView = new List<string>();
            string nuevoNombre;
            foreach (string unaFunc in funcStringDB)
            {

                if (unaFunc.Contains('/'))
                {
                    nuevoNombre = unaFunc.Replace('/', '_');
                }
                else
                {
                    nuevoNombre = unaFunc.Replace(' ', '_');
                }
                funcionalidadesView.Add(nuevoNombre);
            }
            return funcionalidadesView;
        }

        private  bool isItemConst(string nombreDeItem)
        {
            return nombreDeItem.Substring(0, 9).Contains("itm_Const");
        }

        private  bool isItemVar(string nombreDeItem)
        {
            return !isItemConst(nombreDeItem);
        }

        public  string[] itemsString(List<ToolStripMenuItem> allItems)
        {
            var listNombres = allItems.Select(f => "Nombre: " + f.Name + " - Enabled: " + f.Enabled.ToString() + " - Visible: " + f.Visible.ToString());
            return (string[])listNombres.ToArray();
        }

        public  void mostrarAquellosQueTieneTodosSusHijosHabilitados(ToolStripItemCollection menu_toolItems)
        {
            List<ToolStripMenuItem> allItems = this.getAllItems(menu_toolItems);
            foreach (ToolStripMenuItem item in allItems)
            {
                if (todosSusHijosEstanHabilitados(item))
                    item.Enabled = item.Visible = true;
                else
                    item.Enabled = item.Visible = false;
            }
        }

        private  bool todosSusHijosEstanHabilitados(ToolStripMenuItem unItem)
        {
            List<ToolStripMenuItem> itemsHijos = this.getItemsChildren(unItem);
            return itemsHijos.All(i => i.Enabled);
        }

        public  List<ToolStripMenuItem> getItemsChildren(ToolStripMenuItem unItem)
        {
            List<ToolStripMenuItem> itemsHijos = new List<ToolStripMenuItem>();
            if (this.tieneHijos(unItem))
            {
                itemsHijos = getAllItems(unItem.DropDownItems);
            }
            return itemsHijos;
        }

        public  List<ToolStripMenuItem> getAllItems(ToolStripItemCollection menu_toolItems)
        {
            List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();
            foreach (ToolStripItem toolItem in menu_toolItems)
            {
                if (toolItem is ToolStripMenuItem)
                {
                    allItems.Add((ToolStripMenuItem)toolItem);
                    allItems.AddRange(GetItems((ToolStripMenuItem)toolItem));
                }
            }

            return allItems;
        }

        private  IEnumerable<ToolStripMenuItem> GetItems(ToolStripMenuItem item)
        {
            foreach (ToolStripItem dropDownItem in item.DropDownItems)
            {
                if (dropDownItem is ToolStripMenuItem)
                {
                    if (((ToolStripMenuItem)dropDownItem).HasDropDownItems)
                    {
                        foreach (ToolStripMenuItem subItem in GetItems(((ToolStripMenuItem)dropDownItem)))
                            yield return subItem;
                    }
                    yield return ((ToolStripMenuItem)dropDownItem);
                }
            }
        }

        public  int cantidadMaximaDeSubNiveles(ToolStripItemCollection menu_toolItems)
        {
            List<int> allCantidades = new List<int>();
            foreach (ToolStripItem toolItem in menu_toolItems)
            {
                if (toolItem is ToolStripMenuItem)
                {
                    allCantidades.Add(this.cantidadDeSubNivelesDeUnItem((ToolStripMenuItem)toolItem));
                }
            }
            return allCantidades.Max();
        }

        private  int cantidadDeSubNivelesDeUnItem(ToolStripMenuItem item)
        {
            int cantidad = 0;
            foreach (ToolStripItem dropDownItem in item.DropDownItems)
            {
                if (dropDownItem is ToolStripMenuItem)
                {
                    if (((ToolStripMenuItem)dropDownItem).HasDropDownItems)
                    {
                        foreach (ToolStripMenuItem subItem in GetItems(((ToolStripMenuItem)dropDownItem)))
                            cantidad++;
                    }
                }
            }
            return cantidad;
        }

        public  bool tieneHijos(ToolStripMenuItem item)
        {
            return item.HasDropDownItems;
        }
    }
}
