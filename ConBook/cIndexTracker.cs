using System.Dynamic;

namespace ConBook {
  internal static class cIndexTracker {

    internal enum IndexTypeEnum {
      Contact = 1,
      Product = 2,
      Order = 3
    }

    private const string TRACKER_FILE_PATH = "tracker.idx";

    public static int GetIndexValue(IndexTypeEnum xCntIndexType) {
      //funkcja zwracająca wartość zapisanego indeksu
      //xCntIndexType - numerator typu ideksu

      string pTag = xCntIndexType.ToString();

      if (!File.Exists(TRACKER_FILE_PATH)) {
        return 0;
      }
      else {
        try {
          using (StreamReader pReader = new StreamReader(TRACKER_FILE_PATH)) {
            string pLine;

            while ((pLine = pReader.ReadLine()) != null) {
              if (pLine.Contains(pTag)) {
                return int.Parse(pLine.Replace(pTag + ": ", string.Empty));
              }
            }
          }
        } catch (Exception ex) {
          MessageBox.Show("Błąd podczas wczytywania pliku tracker.idx", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      return 0;

    }

    public static bool SetIndexValue(IndexTypeEnum xCntIndexType, int xValue) {
      //funkcja zapisująca nową wartość indeksu do pliku
      //xCntIndexType - numerator typu ideksu
      //xValue - nowa wartość indeksu

      string pTag = xCntIndexType.ToString();

      if (!File.Exists(TRACKER_FILE_PATH)) {

        using (StreamWriter pWriter = new StreamWriter(TRACKER_FILE_PATH)) {

          pWriter.WriteLine(pTag + ": " + xValue);

        }
      } else {
        try {
          string pTempFilePath = "temp.idx";

          using (StreamReader pReader = new StreamReader(TRACKER_FILE_PATH)) {
            string pLine;
            bool pTagWasFound = false;

            using (StreamWriter pWriter = new StreamWriter(pTempFilePath)) {
              while ((pLine = pReader.ReadLine()) != null) {
                if (pLine.Contains(pTag)) {
                  pWriter.WriteLine(pTag + ": " + xValue);
                  pTagWasFound = true;
                } else
                  pWriter.WriteLine(pLine);
              }

              if (!pTagWasFound)
                pWriter.WriteLine(pTag + ": " + xValue);
            }
          }

          File.Delete(TRACKER_FILE_PATH);
          File.Move(pTempFilePath, TRACKER_FILE_PATH);

          return true;
        } 
        catch (Exception ex) {
          MessageBox.Show("Błąd podczas edycji pliku tracker.idx", "Bład", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      return false;

    }

  }
}
