using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServerLibrary
{
    class CSV
    {

        public void saveProduct(Product product) {
            var path = "\\products.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, product.Name, product.Price, product.Amount);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }

        public void saveUser(User user) {
            var path = "\\users.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, user.Balance, user.Password, user.Username);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }
        public void saveInventory(Product product, User user, int amount) {
            var path = "\\inventory.csv";
            String[] csv = File.ReadAllLines(path);
            int id = csv.Length + 1;
            String newLine = string.Format("{0},{1},{2},{3}", id, product.Id, user.Id, amount);
            Array.Resize(ref csv, csv.Length + 1);
            csv[csv.Length - 1] = newLine;
            File.WriteAllLines(path, csv);
        }

        /*    public List<User> readUsers() {

            }
            public List<Product> readProducts() {

            }
            public List<Product> readInventory(int user) {

            }
            */
    }
}
