using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Crud {
    public partial class Form1 : Form {

        private List<Item> itens = new List<Item>();
        private int nextID = 1;

        public Form1() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            string name = textBoxName.Text.Trim();

            if (!string.IsNullOrEmpty(name)) {
                Item newItem = new Item { ID = nextID, Name = name };
                itens.Add(newItem);
                nextID++;

                // Limpar o campo de entrada e exibir uma mensagem
                textBoxName.Text = "";
                MessageBox.Show("Item adicionado com sucesso!");
            }
            else {
                MessageBox.Show("Digite um nome válido para adicionar um item.");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            int ID;
            if (int.TryParse(textBoxId.Text, out ID)) {
                Item itemToRemove = itens.SingleOrDefault(item => item.ID == ID);
                if (itemToRemove != null) {
                    itens.Remove(itemToRemove);

                    // Limpar o campo de entrada e exibir uma mensagem
                    textBoxId.Text = "";
                    MessageBox.Show("Item removido com sucesso!");
                }
                else {
                    MessageBox.Show("Item com o ID especificado não encontrado.");
                }
            }
            else {
                MessageBox.Show("Digite um ID válido para remover um item.");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            int ID;
            if (int.TryParse(textBoxId.Text, out ID)) {
                string newName = textBoxNewName.Text.Trim();
                Item itemToEdit = itens.SingleOrDefault(item => item.ID == ID);
                if (itemToEdit != null) {
                    if (!string.IsNullOrEmpty(newName)) {
                        itemToEdit.Name = newName;

                        // Limpar os campos de entrada e exibir uma mensagem
                        textBoxId.Text = "";
                        textBoxNewName.Text = "";
                        MessageBox.Show("Item editado com sucesso!");
                    }
                    else {
                        MessageBox.Show("Digite um novo nome para editar o item.");
                    }
                }
                else {
                    MessageBox.Show("Item com o ID especificado não encontrado.");
                }
            }
            else {
                MessageBox.Show("Digite um ID válido e um novo nome para editar um item.");
            }
        }

        private void buttonList_Click(object sender, EventArgs e) {
            textBoxList.Clear(); // Limpar o TextBox antes de listar os itens
            foreach (Item item in itens) {
                textBoxList.AppendText(item.ID + " - " + item.Name + "\r\n");
            }
        }

       
    }
}