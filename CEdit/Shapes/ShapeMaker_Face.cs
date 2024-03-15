using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chyoa.CEdit.Shapes.Variations.Faces.Premade;

namespace Chyoa.CEdit.Shapes
{
    public class ShapeMaker_Face
    {
        Variations.Faces.Tools.ShapeMaker_FaceBox shapeMaker_FaceBox = new Variations.Faces.Tools.ShapeMaker_FaceBox();

  
        /// <summary>
        /// Choose one of the faces from the premade options
        /// </summary>
        /// <param name="premadeFace"></param>
        /// <returns></returns>
        public Variations.Faces.Face GetShape_Face_Premade(PremadeFaces premadeFace)
        {
            List<char[,]> lFaceArr_chars = new List<char[,]>();
            List<char[,]> lFaceArr_ColorsFG = new List<char[,]>();
            List<char[,]> lFaceArr_ColorsBG = new List<char[,]>();

            // Assigns arrays based on which default face the user chose
            switch (premadeFace)
            {


                // Tristall is the default
                case PremadeFaces.Tristall:
                default: 
                    lFaceArr_chars = Tristall.Get_ListOfArrays_Chars();
                    lFaceArr_ColorsFG = Tristall.Get_ListOfArrays_ColorsFG();
                    lFaceArr_ColorsBG = Tristall.Get_ListOfArrays_ColorsBG();
                    break;
            }


            AddBorders_To_FaceArrays(lFaceArr_chars, lFaceArr_ColorsFG, lFaceArr_ColorsBG,
                                    out List<char[,]>  lFaceArr_chars_Bordered, out List<char[,]> lFaceArr_ColorsFG_Bordered, out List<char[,]> lFaceArr_ColorsBG_Bordered);

            // Make a new Face shape using the Bordered Face Arrays
            var myFace = new Variations.Faces.Face(lFaceArr_chars_Bordered, lFaceArr_ColorsFG_Bordered, lFaceArr_ColorsBG_Bordered);
            return myFace;
        }


        /// <summary>
        /// Takes in 3 arrays and returns 3 arrays with the face border built around it
        /// </summary>
        /// <param name="lFaceArr_chars"></param>
        /// <param name="lFaceArr_ColorsFG"></param>
        /// <param name="lFaceArr_ColorsBG"></param>
        /// <param name="lFaceArr_chars_Bordered"></param>
        /// <param name="lFaceArr_ColorsFG_Bordered"></param>
        /// <param name="lFaceArr_ColorsBG_Bordered"></param>
        void AddBorders_To_FaceArrays(List<char[,]> lFaceArr_chars, List<char[,]> lFaceArr_ColorsFG, List<char[,]> lFaceArr_ColorsBG,
                                    out List<char[,]> lFaceArr_chars_Bordered, out List<char[,]> lFaceArr_ColorsFG_Bordered, out List<char[,]> lFaceArr_ColorsBG_Bordered)
        {
            lFaceArr_chars_Bordered = new List<char[,]>();
            lFaceArr_ColorsFG_Bordered = new List<char[,]>();
            lFaceArr_ColorsBG_Bordered = new List<char[,]>();


            // For each frame of motion 
            for (int i = 0; i < lFaceArr_chars.Count; i++)
            {
                // Get the three arrays with new boxes around them
                shapeMaker_FaceBox.Get_FaceBoxArrays(lFaceArr_chars[i], lFaceArr_ColorsFG[i], lFaceArr_ColorsBG[i],
                                                    out char[,] tempFaceArr_Chars_Boxed,
                                                    out char[,] tempFaceArr_ColorsFG_Boxed,
                                                    out char[,] tempFaceArr_ColorsBG_Boxed);


                // Add those new boxed arrays to the list (list represents frames of motion)
                lFaceArr_chars_Bordered.Add(tempFaceArr_Chars_Boxed);
                lFaceArr_ColorsFG_Bordered.Add(tempFaceArr_ColorsFG_Boxed);
                lFaceArr_ColorsBG_Bordered.Add(tempFaceArr_ColorsBG_Boxed);
            }
        }

        public enum PremadeFaces
        {
            Tristall
        }



        /*
        /// <summary>
        /// Make a new face shape from new arrays
        /// </summary>
        /// <param name="lFaceArr_chars"></param>
        /// <param name="lFaceArr_ColorsFG"></param>
        /// <param name="lFaceArr_ColorsBG"></param>
        /// <returns></returns>
        Variations.Faces.Face CreateShape_Face(List<char[,]> lFaceArr_chars, List<char[,]> lFaceArr_ColorsFG, List<char[,]> lFaceArr_ColorsBG)
        {
            // Get a lists of arrays that are the input arrays with a box around them
            GetBorderedFaceArrays(lFaceArr_chars, lFaceArr_ColorsFG, lFaceArr_ColorsBG,
                               out List<char[,]> lFaceArr_chars_Boxed,
                               out List<char[,]> lFaceArr_ColorsFG_Boxed,
                               out List<char[,]> lFaceArr_ColorsBG_Boxed);

            Variations.Faces.Face myFace = new Variations.Faces.Face(lFaceArr_chars_Boxed, lFaceArr_ColorsFG_Boxed, lFaceArr_ColorsBG_Boxed);
            myFace.Initialize_AddToMasterList(true);
            return myFace;
        }
        */
    }
}
