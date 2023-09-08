using System.Dynamic;

namespace ConBook {
  internal static class cIndexTracker {

    private const string TRACKER_FILE_PATH = "tracker.idx";

    public static int GetIndexValue(string xTag) {
      //funkcja zwracająca wartość zapisanego indeksu
      //xTag - znacznik indeksu

      if (!File.Exists(TRACKER_FILE_PATH)) {
        return 0;
      }
      else {
        try {
          using (StreamReader pReader = new StreamReader(TRACKER_FILE_PATH)) {
            string pLine;

            while ((pLine = pReader.ReadLine()) != null) {
              if (pLine.Contains(xTag)) {
                return int.Parse(pLine.Replace(xTag + ": ", string.Empty));
              }
            }
          }
        } catch (Exception ex) {
          MessageBox.Show("Błąd podczas wczytywania pliku tracker.idx", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
      return 0;

    }

    public static bool SetIndexValue(string xTag, int xValue) {
      //funkcja zapisująca nową wartość indeksu do pliku
      //xTag - znacznik indeksu
      //xValue - nowa wartość indeksu

      if (!File.Exists(TRACKER_FILE_PATH)) {

        using (StreamWriter pWriter = new StreamWriter(TRACKER_FILE_PATH)) {

          pWriter.WriteLine(xTag + ": " + xValue);

        }
      } else {
        try {
          string pTempFilePath = "temp.idx";

          using (StreamReader pReader = new StreamReader(TRACKER_FILE_PATH)) {
            string pLine;
            bool pTagWasFound = false;

            using (StreamWriter pWriter = new StreamWriter(pTempFilePath)) {
              while ((pLine = pReader.ReadLine()) != null) {
                if (pLine.Contains(xTag)) {
                  pWriter.WriteLine(xTag + ": " + xValue);
                  pTagWasFound = true;
                } else
                  pWriter.WriteLine(pLine);
              }

              if (!pTagWasFound)
                pWriter.WriteLine(xTag + ": " + xValue);
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
