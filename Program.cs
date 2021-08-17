using System;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arrNums = { {1,3,10},                           //TEST İÇİN VERİLEN ÖRNEK NUMARALAR
                               {2,4,10},
                               {5,6,10} 
            };

            int n = 5;                                             //İŞLEM YAPILACAK DİZİ UZUNLUĞU
            //int m = 8;                                             QUERY SAYISI

            long res = arrayManipulation(n,arrNums);               //İSTENİLEN FONKSİYON
            Console.WriteLine(res.ToString());
            Console.ReadKey();
        }

        static long arrayManipulation(int n, int[,] queries)
        {
            long[] arrRes = new long[n];                           //ÜZERİNDE DEĞİŞİKLİK YAPILACAK OLAN DİZİ. LONG VERİLMESİNİN SEBEBİ İSE BÜYÜK SAYILARDAKİ VERİ HACMİ.

            int intyLen = queries.GetLength(0);                    //MULTIDIMENSIONAL ARRAYLERDEKİ SATIR SIRASI. DÖNGÜ GELEN SAYILARDAKİ SATIR SIRASINA GÖRE AYARLANMIŞTIR.
                                                                   //SORUDAKİ 'NUMBER OF OPERATIONS' OLARAK DA DEĞERLENDİRİLEBİLİR. FONKSİYONUN DİNAMİK YAPISI KORUNMUŞTUR.

            for (int i = 0; i < intyLen; i++)
            {
                int a = queries[i,0] - 1;                          //DİZİDE DEĞİŞİKLİĞE BAŞLANACAK INDEKS NUMARASI
                int b = queries[i,1] - 1;                          //DİZİDE DEĞİŞİKLİĞİN BİTECEĞİ INDEKS NUMARASI
                int k = queries[i,2];                              //DİZİYE EKLENECEK OLAN SAYI

                arrRes[a] += k;                                    //INDEKS NUMARASINA GÖRE SAYILARIN EKLENİLDİĞİ YER

                if (b + 1 < n)                                     //DİZİDEKİ OUT OF RANGE KISMININ ÇÖZÜMÜ
                {

                    arrRes[b + 1] -= k;                            //ACCUMULATOR TOPLAMI ALGORİTMASI İÇİN BİTİŞ KISMI İŞARETLENMİŞTİR.
                                                                   //BÖYLELİKLE PARTİAL DATA YÖNTEMİ KULLANILMIŞTIR VE ÇOK BÜYÜK VERİLERLE DAHA HIZLI İŞLEM YAPILABİLECEKTİR.
                }
            }

            long intMaxNum = 0; 
            long intSum = 0;

            for (int i = 0; i < n; i++)
            {
                                                                   //SİNYAL İŞLEMEDE KULLANILAN ACCUMULATOR TEKNİĞİ, GİRİŞ SİNYALİNİN DEĞERLERİNİ TOPLAYARAK İLERLER.
                intSum += arrRes[i];                               //BURADA DA AYNISI MANTIK GÖZETİLMİŞ VE ELEMANLAR TOPLANARAK İLERLENMİŞTİR.
                                                                   //ASLA ARTAMAYCAK OLMASININ SEBEBİ İSE, BİTİŞ OLARAK İŞARETLENEN İNDEKSİN EKSİ DEĞERE SAHİP OLMASIDIR.
                                                                   
                intMaxNum = Math.Max(intMaxNum, intSum);           //BURADA SADECE DİZİDEKİ EN BÜYÜK ELEMAN ELDE EDİLMİŞTİR.

            }
            return intMaxNum;
        }
    }
}
