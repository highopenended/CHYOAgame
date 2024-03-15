using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chyoa.CEdit
{

    public static class DisplayLists
    { 
        public static List<Shapes.Shape> LMasterShapeList = new List<Shapes.Shape>();

        static readonly char[,] CombinedArr_Char     = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        static readonly char[,] CombinedArr_Color_FG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        static readonly char[,] CombinedArr_Color_BG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];

        // Movement Arrays : For shapes that are in motion
        static readonly char[,] MoveArr_Char         = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        static readonly char[,] MoveArr_Color_FG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        static readonly char[,] MoveArr_Color_BG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];

        // Static Arrays : For shapes that are not in motion
        static readonly char[,] StaticArr_Char       = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        static readonly char[,] StaticArr_Color_FG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        static readonly char[,] StaticArr_Color_BG = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];

        // Absolute Top Arrays : Anything in this array will default to the very top
        static readonly char[,] AbsTopArr_Char       = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];  
        static readonly char[,] AbsTopArr_Color_FG   = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];
        static readonly char[,] AbsTopArr_Color_BG   = new char[PUBVAR.windowHeight + 1, PUBVAR.windowWidth];


        
    
        public static void GetUpdatedArrays(out char[,] arrChar, out char[,] arrColorFG, out char[,] arrColorBG)
        {

            // Update to capture any new additions or removals from master shape list
            Update_MasterList_Removals();
            Update_MasterList_Additions();

            // Update the shape coordinates (For Movement)
            Update_ShapeCoordinates();


            // Clear out the arrays and refill them from scratch
            ClearArrays();
            FillPrimaryArrays();
            FillCombinedArray();

            arrChar     = CombinedArr_Char;
            arrColorFG = CombinedArr_Color_FG;
            arrColorBG = CombinedArr_Color_BG;


            //____________________________________________________
            //      INTERNAL METHODS
            //____________________________________________________

            // Update Master List : Removals
            void Update_MasterList_Removals()
            {
                // Only proceed if there are any shapes to be removed
                if(lHFU_RemoveFromMasterList.Count>0)
                {
                    
                    List<Shapes.Shape> tempList = new List<Shapes.Shape>();
                    for (int i = 0; i < LMasterShapeList.Count; i++)
                    {
                        Shapes.Shape checkShape = LMasterShapeList[i];

                        // Only add shapes to tempList that AREN'T on the delete list
                        if (!lHFU_RemoveFromMasterList.Contains(checkShape))
                        {
                            tempList.Add(checkShape);
                        }
                    }
                    LMasterShapeList = tempList;
                    lHFU_RemoveFromMasterList.Clear();
                }
            }

            // Update Master List : Additions
            void Update_MasterList_Additions()
            {
                // Only proceed if there are any shapes to be added
                if (lHFU_AddToMasterList.Count > 0)
                {
                    for (int i = 0; i < lHFU_AddToMasterList.Count; i++)
                    {
                        LMasterShapeList.Add(lHFU_AddToMasterList[i]);
                    }
                    lHFU_AddToMasterList.Clear();
                }
            }


            // Tell each shape to "move" to it's new coordinates by updating it's own Left and Top
            void Update_ShapeCoordinates()
            {
                for (int i = 0; i < LMasterShapeList.Count; i++)
                {
                    LMasterShapeList[i].UpdateOnTick();
                }
            }




            // Clear primary arrays and combined arrays
            void ClearArrays()
            {                
                foreach (char[,] arr in lPrimaryArrays) { Array.Clear(arr, 0, arr.Length); }
                foreach (char[,] arr in lCombinedArrays) { Array.Clear(arr, 0, arr.Length); }
            }

            // Fill Primary Arrays from scratch
            void FillPrimaryArrays()
            {

                for (int i = LMasterShapeList.Count-1; i > -1; i--)
                {
                    Shapes.Shape checkShape = LMasterShapeList[i];

                    // Only draw if shape is visible
                    if (checkShape.IsVisible)
                    {
                        char[,] shapeArr_Char = checkShape.ArrChars;
                        char[,] shapeArr_ColorFG = checkShape.ArrColors_FG;
                        char[,] shapeArr_ColorBG = checkShape.ArrColors_BG;

                        if(checkShape.ArrColors_BG==null)
                        {

                        }

                        switch (checkShape.ShapeStatus)
                        {
                            case Shapes.Shape.ShapeStatuses.Static:
                                AddToStaticArray(checkShape, shapeArr_Char, shapeArr_ColorFG, shapeArr_ColorBG);
                                break;

                            case Shapes.Shape.ShapeStatuses.Moving:
                                AddToMovementArray(checkShape, shapeArr_Char, shapeArr_ColorFG, shapeArr_ColorBG);
                                break;

                            case Shapes.Shape.ShapeStatuses.AbsoluteTop:
                                AddToAsbTopArray(checkShape, shapeArr_Char, shapeArr_ColorFG, shapeArr_ColorBG);
                                break;
                        }
                    }
                }

                // Add to the Movement Array
                void AddToMovementArray(Shapes.Shape _checkShape, char[,] _shapeArr_Char, char[,] _shapeArr_ColorFG, char[,] _shapeArr_ColorBG)
                {
                    int iadj, jadj;
                    for (int i = 0; i < _shapeArr_Char.GetUpperBound(0); i++)
                    {
                        iadj = _checkShape.Top + i;
                        if (iadj <= MoveArr_Char.GetUpperBound(0) && iadj >= 0)
                        {
                            for (int j = 0; j < _shapeArr_Char.GetUpperBound(1); j++)
                            {

                                jadj = _checkShape.Left + j;
                                if (jadj <= MoveArr_Char.GetUpperBound(1) && jadj >= 0)
                                {
                                    if (MoveArr_Char[iadj, jadj] == '\0')
                                    {
                                        if (_shapeArr_Char[i, j] != ' ')
                                        {
                                            MoveArr_Char[iadj, jadj] = _shapeArr_Char[i, j];
                                            MoveArr_Color_FG[iadj, jadj] = _shapeArr_ColorFG[i, j];
                                            MoveArr_Color_BG[iadj, jadj] = _shapeArr_ColorBG[i, j];
                                        }
                                        else if (_shapeArr_ColorFG[i, j] != '\0' || _shapeArr_ColorBG[i, j] != '\0')
                                        {
                                            MoveArr_Char[iadj, jadj] = ' ';
                                            MoveArr_Color_FG[iadj, jadj] = _shapeArr_ColorFG[i, j];
                                            MoveArr_Color_BG[iadj, jadj] = _shapeArr_ColorBG[i, j];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Add to the Static Array
                void AddToStaticArray(Shapes.Shape _checkShape, char[,] _shapeArr_Char, char[,] _shapeArr_ColorFG, char[,] _shapeArr_ColorBG)
                {
                    int iadj, jadj;
                    for (int i = 0; i < _shapeArr_Char.GetUpperBound(0); i++)
                    {
                        iadj = _checkShape.Top + i;
                        if (iadj <= StaticArr_Char.GetUpperBound(0) && iadj >= 0)
                        {
                            for (int j = 0; j < _shapeArr_Char.GetUpperBound(1); j++)
                            {
                                jadj = _checkShape.Left + j;
                                if (jadj <= StaticArr_Char.GetUpperBound(1) && jadj>=0)
                                {
                                    if (StaticArr_Char[iadj, jadj] == '\0')
                                    {
                                        if (_shapeArr_Char[i, j] != ' ')
                                        {
                                            StaticArr_Char[iadj, jadj] = _shapeArr_Char[i, j];
                                            StaticArr_Color_FG[iadj, jadj] = _shapeArr_ColorFG[i, j];
                                            StaticArr_Color_BG[iadj, jadj] = _shapeArr_ColorBG[i, j];
                                        }
                                        else if (_shapeArr_ColorFG[i, j] != '\0' || _shapeArr_ColorBG[i, j] != '\0')
                                        {
                                            StaticArr_Char[iadj, jadj] = ' ';
                                            StaticArr_Color_FG[iadj, jadj] = _shapeArr_ColorFG[i, j];
                                            StaticArr_Color_BG[iadj, jadj] = _shapeArr_ColorBG[i, j];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Add to the Absolute Top Array
                void AddToAsbTopArray(Shapes.Shape _checkShape, char[,] _shapeArr_Char, char[,] _shapeArr_ColorFG, char[,] _shapeArr_ColorBG)
                {
                    int iadj, jadj;
                    for (int i = 0; i < _shapeArr_Char.GetUpperBound(0)+1; i++)
                    {
                        iadj = _checkShape.Top + i;
                        if (iadj <= AbsTopArr_Char.GetUpperBound(0) && iadj >= 0)
                        {
                            for (int j = 0; j < _shapeArr_Char.GetUpperBound(1)+1; j++)
                            {
                                jadj = _checkShape.Left + j;
                                if (jadj <= AbsTopArr_Char.GetUpperBound(1) && jadj >= 0)
                                {
                                    if (AbsTopArr_Char[iadj, jadj] == '\0')
                                    {
                                        if (_shapeArr_Char[i, j] != ' ')
                                        {
                                            AbsTopArr_Char[iadj, jadj] = _shapeArr_Char[i, j];
                                            AbsTopArr_Color_FG[iadj, jadj] = _shapeArr_ColorFG[i, j];
                                            AbsTopArr_Color_BG[iadj, jadj] = _shapeArr_ColorBG[i, j];
                                        }
                                        else if (_shapeArr_ColorFG[i, j] != '\0' || _shapeArr_ColorBG[i, j] != '\0')
                                        {
                                            AbsTopArr_Char[iadj, jadj] = ' ';
                                            AbsTopArr_Color_FG[iadj, jadj] = _shapeArr_ColorFG[i, j];
                                            AbsTopArr_Color_BG[iadj, jadj] = _shapeArr_ColorBG[i, j];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            // Fill Combined Array from the Primary Arrays (AbsTop > Move > Static)
            void FillCombinedArray()
            {
                for (int i = 0; i < CombinedArr_Char.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < CombinedArr_Char.GetUpperBound(1); j++)
                    {
                        // 1 : Abs Top
                        CombinedArr_Char[i, j]          = AbsTopArr_Char[i, j];
                        CombinedArr_Color_FG[i, j]      = AbsTopArr_Color_FG[i, j];
                        CombinedArr_Color_BG[i, j]      = AbsTopArr_Color_BG[i, j];

                        // 2 : Movement
                        if (CombinedArr_Char[i,j] == '\0')
                        {
                            CombinedArr_Char[i, j]      = MoveArr_Char[i, j];
                            CombinedArr_Color_FG[i, j]  = MoveArr_Color_FG[i, j];
                            CombinedArr_Color_BG[i, j]  = MoveArr_Color_BG[i, j];
                        }

                        // 3 : Static
                        if (CombinedArr_Char[i, j] == '\0')
                        {
                            CombinedArr_Char[i, j]      = StaticArr_Char[i, j];
                            CombinedArr_Color_FG[i, j]  = StaticArr_Color_FG[i, j];
                            CombinedArr_Color_BG[i, j]  = StaticArr_Color_BG[i, j];
                        }
                    }
                }
            }
        }
                          

        // HFU -- Hold for update (updates on tick)
        static readonly List<Shapes.Shape> lHFU_RemoveFromMasterList = new List<Shapes.Shape>();
        static readonly List<Shapes.Shape> lHFU_AddToMasterList = new List<Shapes.Shape>();





        /// <summary>
        /// Removes a shape to the master list (at the beginning of the next tick)
        /// </summary>
        /// <param name="shapeToRemove"></param>
        public static void AddToWaitList_RemoveFromMasterList(Shapes.Shape shapeToRemove)
        {
            if (LMasterShapeList.Contains(shapeToRemove))
            {
                lHFU_RemoveFromMasterList.Add(shapeToRemove);
            }
        }
        
        /// <summary>
        /// Adds a shape to the master list (at the beginning of the next tick)
        /// </summary>
        /// <param name="shapeToAdd"></param>
        public static void AddToWaitList_AddToMasterList(Shapes.Shape shapeToAdd)
        {
            if (!LMasterShapeList.Contains(shapeToAdd) && !lHFU_AddToMasterList.Contains(shapeToAdd)) { lHFU_AddToMasterList.Add(shapeToAdd); }
        }



        public static readonly List<char[,]> lCombinedArrays = new List<char[,]>
        {
            CombinedArr_Char,
            CombinedArr_Color_FG,
            CombinedArr_Color_BG
        };
        public static readonly List<char[,]> lPrimaryArrays = new List<char[,]>
        {
            MoveArr_Char,
            StaticArr_Char,
            AbsTopArr_Char,

            MoveArr_Color_FG,
            StaticArr_Color_FG,
            AbsTopArr_Color_FG,

            MoveArr_Color_BG,
            StaticArr_Color_BG,
            AbsTopArr_Color_BG
        };
    }
}
