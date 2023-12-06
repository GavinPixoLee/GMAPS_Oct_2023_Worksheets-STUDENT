using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{

    private HMatrix2D mat = new HMatrix2D();
    // Start is called before the first frame update
    void Start()
    {
        mat.SetIdentity();
        mat.Print();
        Question2();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D(1, 2, 1, 0, 1, 0, 2, 3, 4);
        HMatrix2D mat2 = new HMatrix2D(5, 4, 2, 1, 5, 7, 3, 2, 9);
        HMatrix2D mat3 = new HMatrix2D(1, 0, 3, 0, 1, 2, 0, 0, 1);

        HVector2D vec1 = new HVector2D(2, 6);

        mat1 = mat1 * mat2;
        mat1.Print();
        vec1 = mat3 * vec1;
        Debug.Log(vec1.x + ", " + vec1.y);
    }
}
