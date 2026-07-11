namespace PlanningWebAgit.Services;

public class PemerataanProduksi {
    public int[] Pemerataan(int[] arrayAsli) {
        int n = arrayAsli.Length;
        int[] arrayHasil = new int[n];

        // hitung total
        int totalHariAktif = 0;
        int totalProduksi = 0;
        for (int i = 0; i < n; i++) {
            totalProduksi += arrayAsli[i];
            if (arrayAsli[i] != 0) {
                totalHariAktif += 1;
            }
        }

        // jaga2 jika full libur
        if (totalHariAktif == 0) {
            return arrayHasil;
        }

        int nilaiRataan = totalProduksi / totalHariAktif;
        int sisa = totalProduksi % totalHariAktif;
        
        // isi arrayHasil
        for (int i = 0; i < n; i++) {
            if (arrayAsli[i] == 0) {
                arrayHasil[i] = 0;
            } else {
                arrayHasil[i] = nilaiRataan;
            }
        }

        // bagikan sisa ke hari aktif dengan nilai asli terbesar
        for (int i = 0; i < sisa; i++) {
            int idxTerbesar = -1;
            for (int j = 0; j < n; j++) {
                if (arrayAsli[j] != 0 && arrayHasil[j] == nilaiRataan)
                {
                    if (idxTerbesar < 0 || arrayAsli[j] > arrayAsli[idxTerbesar])
                    {
                        idxTerbesar = j;
                    }
                }
            }
            arrayHasil[idxTerbesar] += 1;
        }

        return arrayHasil;
    }
}