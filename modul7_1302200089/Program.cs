using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul7_1302200089
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankTransferConfig bankTFconf = new BankTransferConfig();
            dynamic config = bankTFconf.ReadJson();

            if (config.lang == "en")
            {
                Console.Write("Please insert the amount of money to transfer: ");
            }
            else if (config.lang == "id")
            {
                Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
            }

            string uangTFcnfg1 = Console.ReadLine();
            int cekThreshold = int.Parse(uangTFcnfg1);

            int biayaTF;
            if (cekThreshold <= (int)config.transfer.threshold)
            {
                biayaTF = config.transfer.low_fee;
            }
            else
            {
                biayaTF = config.transfer.high_fee;
            }

            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee = " + biayaTF);
                Console.WriteLine("Total amount = " + (biayaTF + cekThreshold));
                Console.WriteLine("Select transfer method");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Biaya transfer = " + biayaTF);
                Console.WriteLine("Total biaya = " + (biayaTF + cekThreshold));
                Console.WriteLine("Pilih metode transfer");
            }

            int idx = 0;
            foreach (var mthd in config.methods)
            {
                idx++;
                Console.WriteLine(idx + ". " + mthd);
            }

            //Console.WriteLine();
            string mtdhTF = Console.ReadLine();
            if (config.lang == "id")
            {
                Console.Write("Metode transfer yang dipilih adalah ");
                if (mtdhTF == "1")
                {
                    Console.WriteLine("RTO (real-time)");
                }
                else if (mtdhTF == "2")
                {
                    Console.WriteLine("SKN");
                }
                else if (mtdhTF == "3")
                {
                    Console.WriteLine("RTGS");
                }
                else if (mtdhTF == "4")
                {
                    Console.WriteLine("BI FAST");
                }
                else
                {
                    Console.WriteLine("Pemilihan metode transfer tidak valid!");
                }
            }
            else if (config.lang == "en")
            {
                Console.Write("The method you have chosen is ");
                if (mtdhTF == "1")
                {
                    Console.WriteLine("RTO (real-time)");
                }
                else if (mtdhTF == "2")
                {
                    Console.WriteLine("SKN");
                }
                else if (mtdhTF == "3")
                {
                    Console.WriteLine("RTGS");
                }
                else if (mtdhTF == "4")
                {
                    Console.WriteLine("BI FAST");
                }
                else
                {
                    Console.WriteLine("Transfer method choice is not valid!");
                }

            }
            string konfirmasi;
            if (config.lang == "en")
            {
                Console.WriteLine("Please type '" + config.confirmation.en + "' to confirm the transaction:");
                konfirmasi = Console.ReadLine();
                if (konfirmasi == (string)config.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                }
                else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Ketik '" + config.confirmation.id + "' untuk mengkonfirmasi transaksi:");
                konfirmasi = Console.ReadLine();
                if (konfirmasi == (string)config.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }


        }
    }
}
