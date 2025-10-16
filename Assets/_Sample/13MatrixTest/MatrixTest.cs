using UnityEngine;
using TMPro;

namespace sample
{
    public class MatrixTest : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI metrixText;

        private Matrix4x4 maxtrix;
        #endregion

        #region Unity Event Method
        private void Update()
        {
            maxtrix = this.transform.localToWorldMatrix;

            metrixText.text = $"{maxtrix.m00:0.##},{maxtrix.m01:0.##},{maxtrix.m02:0.##},{maxtrix.m03:0.##}\n";
            metrixText.text += $"{maxtrix.m10:0.##},{maxtrix.m11:0.##},{maxtrix.m12:0.##},{maxtrix.m13:0.##}\n";
            metrixText.text += $"{maxtrix.m20:0.##},{maxtrix.m21:0.##},{maxtrix.m22:0.##},{maxtrix.m23:0.##}\n";
            metrixText.text += $"{maxtrix.m30:0.##},{maxtrix.m31:0.##},{maxtrix.m32:0.##},{maxtrix.m33:0.##}\n";



        }
        #endregion
    }
}
