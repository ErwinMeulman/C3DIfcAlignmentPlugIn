using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Civil;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices;
using Autodesk.Windows;
using C3DIfcAlignmentPlugIn.Forms;
using C3DIfcAlignmentPlugIn.forms;
using Ifc4x1;
using Microsoft.Win32;

namespace C3DIfcAlignmentPlugIn.PlugIn
{
	// Token: 0x02000003 RID: 3
	public class C3DIfcAlignmentAddIn
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000020FF File Offset: 0x000002FF
		private BitmapImage GetBitmap(string fileName)
		{
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.UriSource = new Uri(string.Format("pack://application:,,,/{0};component/{1}", Assembly.GetExecutingAssembly().GetName().Name, fileName));
			bitmapImage.EndInit();
			return bitmapImage;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002138 File Offset: 0x00000338
		private static IfcBoolean CheckForConvexity(ProfileEntity entity)
		{
			bool value = false;
			switch (entity.EntityType)
			{
			case 258:
				if (((ProfileCircular)entity).CurveType == 769)
				{
					value = true;
				}
				break;
			case 259:
				if (((ProfileParabolaSymmetric)entity).CurveType == 769)
				{
					value = true;
				}
				break;
			case 260:
				if (((ProfileParabolaAsymmetric)entity).CurveType == 769)
				{
					value = true;
				}
				break;
			}
			return new IfcBoolean
			{
				_value = value
			};
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021B4 File Offset: 0x000003B4
		private static IfcGloballyUniqueId CreateUniqueId()
		{
			string text = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
			text = text.Replace("=", "");
			text = text.Replace("+", "");
			text = text.Replace("/", "");
			return new IfcGloballyUniqueId
			{
				_value = text
			};
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002214 File Offset: 0x00000414
		private static IfcCartesianPoint CreateIfcPoint3D(double x, double y, double z)
		{
			IfcLengthMeasure item = new IfcLengthMeasure
			{
				_value = x
			};
			IfcLengthMeasure item2 = new IfcLengthMeasure
			{
				_value = y
			};
			IfcLengthMeasure item3 = new IfcLengthMeasure
			{
				_value = z
			};
			List<IfcLengthMeasure> list = new List<IfcLengthMeasure>();
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			return new IfcCartesianPoint
			{
				m_Coordinates = list
			};
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002270 File Offset: 0x00000470
		private static IfcCartesianPoint CreateIfcPoint2D(double x, double y)
		{
			IfcLengthMeasure item = new IfcLengthMeasure
			{
				_value = x
			};
			IfcLengthMeasure item2 = new IfcLengthMeasure
			{
				_value = y
			};
			List<IfcLengthMeasure> list = new List<IfcLengthMeasure>();
			list.Add(item);
			list.Add(item2);
			return new IfcCartesianPoint
			{
				m_Coordinates = list
			};
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000022B8 File Offset: 0x000004B8
		private static IfcBoolean CheckTheIfcTime(string civilClock)
		{
			bool value = !(civilClock == "True") && !(civilClock == "DirectionRight");
			return new IfcBoolean
			{
				_value = value
			};
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022F4 File Offset: 0x000004F4
		private static IfcBoolean CheckTangential(string civilIsTangential)
		{
			bool value = civilIsTangential == "Free" || civilIsTangential == "FloatOnNext";
			return new IfcBoolean
			{
				_value = value
			};
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000232C File Offset: 0x0000052C
		private static IfcPlaneAngleMeasure GetIfcDirection(double civilDirection)
		{
			double value = 1.5707963267948966 - civilDirection;
			return new IfcPlaneAngleMeasure
			{
				_value = value
			};
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002354 File Offset: 0x00000554
		private static IfcTransitionCurveType GetIfcSpiralType(SpiralType civilSpiral)
		{
			IfcTransitionCurveType ifcTransitionCurveType = new IfcTransitionCurveType();
			switch (civilSpiral)
			{
			case 256:
				goto IL_61;
			case 257:
			case 258:
				return ifcTransitionCurveType;
			case 259:
				goto IL_6A;
			case 260:
				goto IL_73;
			case 261:
				goto IL_7C;
			case 262:
				break;
			default:
				switch (civilSpiral)
				{
				case 1048832:
					goto IL_61;
				case 1048833:
				case 1048834:
					return ifcTransitionCurveType;
				case 1048835:
					goto IL_6A;
				case 1048836:
					goto IL_73;
				case 1048837:
					goto IL_7C;
				case 1048838:
					break;
				default:
					return ifcTransitionCurveType;
				}
				break;
			}
			ifcTransitionCurveType._value = 0;
			return ifcTransitionCurveType;
			IL_61:
			ifcTransitionCurveType._value = 2;
			return ifcTransitionCurveType;
			IL_6A:
			ifcTransitionCurveType._value = 1;
			return ifcTransitionCurveType;
			IL_73:
			ifcTransitionCurveType._value = 4;
			return ifcTransitionCurveType;
			IL_7C:
			ifcTransitionCurveType._value = 5;
			return ifcTransitionCurveType;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023E8 File Offset: 0x000005E8
		private static IfcRatioMeasure GetParabola2Gradient(ProfileParabolaAsymmetric civilParabolaA)
		{
			double value;
			if (civilParabolaA.GradeIn > civilParabolaA.GradeOut)
			{
				value = -civilParabolaA.AsymmetricLength1 / civilParabolaA.K * 100.0 + civilParabolaA.GradeIn;
			}
			else
			{
				value = civilParabolaA.AsymmetricLength1 / civilParabolaA.K * 100.0 + civilParabolaA.GradeIn;
			}
			return new IfcRatioMeasure
			{
				_value = value
			};
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002450 File Offset: 0x00000650
		private static List<AlignmentEntity> SortC3DAlignmentEntities(Alignment civilAlignment)
		{
			List<AlignmentEntity> list = new List<AlignmentEntity>();
			AlignmentEntityCollection entities = civilAlignment.Entities;
			int count = entities.Count;
			list.Add(entities[entities.FirstEntity - 1]);
			int i = 1;
			AlignmentEntity alignmentEntity = list[0];
			while (i <= count - 1)
			{
				AlignmentEntity alignmentEntity2 = entities[alignmentEntity.EntityAfter - 1];
				list.Add(alignmentEntity2);
				alignmentEntity = alignmentEntity2;
				i++;
			}
			return list;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000024BC File Offset: 0x000006BC
		private static List<ProfileEntity> SortC3DProfileEntities(Profile civilProfile)
		{
			List<ProfileEntity> list = new List<ProfileEntity>();
			ProfileEntityCollection entities = civilProfile.Entities;
			int count = entities.Count;
			list.Add(entities[checked((int)entities.FirstEntity) - 1]);
			int i = 1;
			ProfileEntity profileEntity = list[0];
			while (i <= count - 1)
			{
				ProfileEntity profileEntity2 = entities[checked((int)profileEntity.EntityAfter) - 1];
				list.Add(profileEntity2);
				profileEntity = profileEntity2;
				i++;
			}
			return list;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002528 File Offset: 0x00000728
		private static Point3d ConvertIfcPoint2D(IfcCartesianPoint ifcPoint)
		{
			double value = ifcPoint.m_Coordinates[0]._value;
			double value2 = ifcPoint.m_Coordinates[1]._value;
			double num = 0.0;
			return new Point3d(value, value2, num);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000256C File Offset: 0x0000076C
		private static double ConvertIfcDirection(double ifcDir)
		{
			double num = 1.5707963267948966 - ifcDir;
			if (num < 0.0)
			{
				num = 6.283185307179586 + num;
			}
			return num;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000025A0 File Offset: 0x000007A0
		private static Point3d CalculateLinePoint(IfcLineSegment2D ifcLine, double dist)
		{
			double num = C3DIfcAlignmentAddIn.ConvertIfcDirection(ifcLine.m_StartDirection._value);
			double num2 = 0.0;
			double num3;
			double num4;
			if (num >= 0.0 && num < 1.5707963267948966)
			{
				num3 = ifcLine.m_StartPoint.m_Coordinates[0]._value + dist * ifcLine.m_SegmentLength._value._value * Math.Cos(1.5707963267948966 - num);
				num4 = ifcLine.m_StartPoint.m_Coordinates[1]._value + Math.Sin(1.5707963267948966 - num) * ifcLine.m_SegmentLength._value._value * dist;
			}
			else if (num >= 1.5707963267948966 && num < 3.141592653589793)
			{
				num3 = ifcLine.m_StartPoint.m_Coordinates[0]._value + dist * ifcLine.m_SegmentLength._value._value * Math.Cos(num - 1.5707963267948966);
				num4 = ifcLine.m_StartPoint.m_Coordinates[1]._value - Math.Sin(num - 1.5707963267948966) * ifcLine.m_SegmentLength._value._value * dist;
			}
			else if (num >= 3.141592653589793 && num < 4.71238898038469)
			{
				num3 = ifcLine.m_StartPoint.m_Coordinates[0]._value - dist * ifcLine.m_SegmentLength._value._value * Math.Cos(num - 3.141592653589793);
				num4 = ifcLine.m_StartPoint.m_Coordinates[1]._value - Math.Sin(num - 3.141592653589793) * ifcLine.m_SegmentLength._value._value * dist;
			}
			else
			{
				num3 = ifcLine.m_StartPoint.m_Coordinates[0]._value - dist * ifcLine.m_SegmentLength._value._value * Math.Cos(num - 4.71238898038469);
				num4 = ifcLine.m_StartPoint.m_Coordinates[1]._value + Math.Sin(num - 4.71238898038469) * ifcLine.m_SegmentLength._value._value * dist;
			}
			return new Point3d(num3, num4, num2);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002808 File Offset: 0x00000A08
		private static Point3d GetArcCentre(IfcCircularArcSegment2D ifcArc)
		{
			double num = C3DIfcAlignmentAddIn.ConvertIfcDirection(ifcArc.m_StartDirection._value);
			double value = ifcArc.m_StartPoint.m_Coordinates[0]._value;
			double value2 = ifcArc.m_StartPoint.m_Coordinates[1]._value;
			double value3 = ifcArc.m_Radius._value._value;
			double num2;
			double num3;
			if (num >= 0.0 && num < 1.5707963267948966)
			{
				if (!ifcArc.m_IsCCW._value)
				{
					num2 = value + value3 * Math.Cos(num);
					num3 = value2 - value3 * Math.Sin(num);
				}
				else
				{
					num2 = value - value3 * Math.Cos(num);
					num3 = value2 + value3 * Math.Sin(num);
				}
			}
			else if (num >= 1.5707963267948966 && num < 3.141592653589793)
			{
				if (!ifcArc.m_IsCCW._value)
				{
					num2 = value - value3 * Math.Cos(-num + 3.141592653589793);
					num3 = value2 - value3 * Math.Sin(-num + 3.141592653589793);
				}
				else
				{
					num2 = value + value3 * Math.Cos(-num + 3.141592653589793);
					num3 = value2 + value3 * Math.Sin(-num + 3.141592653589793);
				}
			}
			else if (num >= 3.141592653589793 && num < 4.71238898038469)
			{
				if (!ifcArc.m_IsCCW._value)
				{
					num2 = value - value3 * Math.Cos(num + 3.141592653589793);
					num3 = value2 + value3 * Math.Sin(num + 3.141592653589793);
				}
				else
				{
					num2 = value + value3 * Math.Cos(num + 3.141592653589793);
					num3 = value2 - value3 * Math.Sin(num + 3.141592653589793);
				}
			}
			else if (!ifcArc.m_IsCCW._value)
			{
				num2 = value + value3 * Math.Cos(-num + 6.283185307179586);
				num3 = value2 + value3 * Math.Sin(-num + 6.283185307179586);
			}
			else
			{
				num2 = value - value3 * Math.Cos(-num + 6.283185307179586);
				num3 = value2 - value3 * Math.Sin(-num + 6.283185307179586);
			}
			return new Point3d(num2, num3, 0.0);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002A50 File Offset: 0x00000C50
		private static Point3d GetArcPoint(IfcCircularArcSegment2D ifcArc, double dist)
		{
			Point3d arcCentre = C3DIfcAlignmentAddIn.GetArcCentre(ifcArc);
			double x = arcCentre.X;
			double y = arcCentre.Y;
			double value = ifcArc.m_StartPoint.m_Coordinates[0]._value;
			double value2 = ifcArc.m_StartPoint.m_Coordinates[1]._value;
			double value3 = ifcArc.m_Radius._value._value;
			double value4 = ifcArc.m_SegmentLength._value._value;
			double num = Math.Atan2(value2 - y, value - x);
			if (!ifcArc.m_IsCCW._value)
			{
				num -= dist * value4 / value3;
			}
			else
			{
				num += dist * value4 / value3;
			}
			double num2 = x + value3 * Math.Cos(num);
			double num3 = y + value3 * Math.Sin(num);
			return new Point3d(num2, num3, 0.0);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002B28 File Offset: 0x00000D28
		private static bool CheckTheCivilTime(bool isCCW)
		{
			bool result = false;
			if (!isCCW)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002B40 File Offset: 0x00000D40
		private static int GetQuadrant(IfcCircularArcSegment2D ifcArc)
		{
			Point3d arcCentre = C3DIfcAlignmentAddIn.GetArcCentre(ifcArc);
			double x = arcCentre.X;
			double y = arcCentre.Y;
			double value = ifcArc.m_StartPoint.m_Coordinates[0]._value;
			double value2 = ifcArc.m_StartPoint.m_Coordinates[1]._value;
			int result;
			if (value < x)
			{
				if (value2 < y)
				{
					result = 3;
				}
				else
				{
					result = 4;
				}
			}
			else if (value2 < y)
			{
				result = 2;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002BB0 File Offset: 0x00000DB0
		private static Point3d GetClothoidIntersection(IfcTransitionCurveSegment2D spiral)
		{
			double value = spiral.m_SegmentLength._value._value;
			double num = C3DIfcAlignmentAddIn.ConvertIfcDirection(spiral.m_StartDirection._value);
			double value2;
			if (spiral.o_EndRadius == null)
			{
				value2 = spiral.o_StartRadius._value;
			}
			else
			{
				value2 = spiral.o_EndRadius._value;
			}
			double num2 = value - Math.Pow(value, 3.0) / (40.0 * Math.Pow(value2, 2.0)) + Math.Pow(value, 5.0) / (3456.0 * Math.Pow(value2, 4.0)) - Math.Pow(value, 7.0) / (599040.0 * Math.Pow(value2, 6.0));
			double num3 = Math.Pow(value, 2.0) / (6.0 * value2) - Math.Pow(value, 4.0) / (336.0 * Math.Pow(value2, 3.0)) + Math.Pow(value, 6.0) / (42240.0 * Math.Pow(value2, 5.0)) - Math.Pow(value, 8.0) / (9676800.0 * Math.Pow(value2, 7.0));
			double a = value / (2.0 * value2);
			double num4 = num3 / Math.Tan(a);
			double num5 = num2 - num4;
			num5 *= Math.Cos(-num);
			double num6 = -num5 * Math.Sin(-num);
			num5 += spiral.m_StartPoint.m_Coordinates[0]._value;
			num6 += spiral.m_StartPoint.m_Coordinates[1]._value;
			return new Point3d(num5, num6, 0.0);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002DA4 File Offset: 0x00000FA4
		private static Point3d GetClothoidEnd(IfcTransitionCurveSegment2D spiral)
		{
			double value = spiral.m_SegmentLength._value._value;
			double num = C3DIfcAlignmentAddIn.ConvertIfcDirection(spiral.m_StartDirection._value);
			double value2;
			if (spiral.o_EndRadius == null)
			{
				value2 = spiral.o_StartRadius._value;
			}
			else
			{
				value2 = spiral.o_EndRadius._value;
			}
			double num2 = value - Math.Pow(value, 3.0) / (40.0 * Math.Pow(value2, 2.0)) + Math.Pow(value, 5.0) / (3456.0 * Math.Pow(value2, 4.0)) - Math.Pow(value, 7.0) / (599040.0 * Math.Pow(value2, 6.0));
			double num3 = Math.Pow(value, 2.0) / (6.0 * value2) - Math.Pow(value, 4.0) / (336.0 * Math.Pow(value2, 3.0)) + Math.Pow(value, 6.0) / (42240.0 * Math.Pow(value2, 5.0)) - Math.Pow(value, 8.0) / (9676800.0 * Math.Pow(value2, 7.0));
			num2 = num2 * Math.Cos(-num) + num3 * Math.Sin(-num);
			num3 = -num2 * Math.Sin(-num) + num3 * Math.Cos(-num);
			num2 += spiral.m_StartPoint.m_Coordinates[0]._value;
			num3 += spiral.m_StartPoint.m_Coordinates[1]._value;
			return new Point3d(num2, num3, 0.0);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002F84 File Offset: 0x00001184
		private static List<string> CreateIfcHorizontalEntityList(IfcAlignment2DHorizontal align)
		{
			List<string> list = new List<string>();
			foreach (IfcAlignment2DHorizontalSegment ifcAlignment2DHorizontalSegment in align.m_Segments)
			{
				if (ifcAlignment2DHorizontalSegment.m_CurveGeometry.GetType() == typeof(IfcLineSegment2D))
				{
					list.Add("Line");
				}
				else if (ifcAlignment2DHorizontalSegment.m_CurveGeometry.GetType() == typeof(IfcCircularArcSegment2D))
				{
					list.Add("Arc");
				}
				else if (ifcAlignment2DHorizontalSegment.m_CurveGeometry.GetType() == typeof(IfcTransitionCurveSegment2D))
				{
					list.Add("Spiral");
				}
			}
			return list;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003058 File Offset: 0x00001258
		private static Point3d CheckForVicintiy(double compareX, double compareY, IfcCartesianPoint ifcPoint)
		{
			double num = ifcPoint.m_Coordinates[0]._value;
			double num2 = ifcPoint.m_Coordinates[1]._value;
			if (Math.Sqrt(Math.Pow(Math.Abs(compareX - ifcPoint.m_Coordinates[0]._value), 2.0) + Math.Pow(Math.Abs(compareY - ifcPoint.m_Coordinates[1]._value), 2.0)) <= 0.001)
			{
				num = compareX;
				num2 = compareY;
			}
			return new Point3d(num, num2, 0.0);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000030FC File Offset: 0x000012FC
		private static Point2d CalculateTangentPoint(IfcAlignment2DVerSegLine tangent, double dist)
		{
			double num = tangent.m_HorizontalLength._value._value * dist;
			double num2 = tangent.m_StartDistAlong._value + num;
			double num3 = tangent.m_StartHeight._value + tangent.m_StartGradient._value * num;
			return new Point2d(num2, num3);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000314C File Offset: 0x0000134C
		private static Point2d CalculateVerParabolaPoint(IfcAlignment2DVerSegParabolicArc parabola, double dist)
		{
			double num = parabola.m_HorizontalLength._value._value * dist;
			double num2 = parabola.m_StartDistAlong._value + num;
			double num3;
			if (!parabola.m_IsConvex._value)
			{
				num3 = Math.Pow(num, 2.0) / (2.0 * -parabola.m_ParabolaConstant._value._value);
			}
			else
			{
				num3 = Math.Pow(num, 2.0) / (2.0 * parabola.m_ParabolaConstant._value._value);
			}
			double num4 = parabola.m_StartHeight._value + parabola.m_StartGradient._value * num + num3;
			return new Point2d(num2, num4);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003204 File Offset: 0x00001404
		private static Point2d CalculateVerArcPoint(IfcAlignment2DVerSegCircularArc arc, double dist)
		{
			double num = arc.m_HorizontalLength._value._value * dist;
			double num2 = arc.m_StartDistAlong._value + num;
			double num3 = 0.0;
			double num4 = arc.m_StartHeight._value + arc.m_StartGradient._value * num + num3;
			return new Point2d(num2, num4);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00003260 File Offset: 0x00001460
		[CommandMethod("IFCImportTest")]
		public void ifcimporttest()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			bool? flag = openFileDialog.ShowDialog();
			string fileName = openFileDialog.FileName;
			Import import = new Import();
			import.ShowDialog();
			bool importTest = import.importTest;
			int simplifier = import.simplifier;
			if (flag == true && importTest)
			{
				IfcAlignmentReader ifcAlignmentReader = new IfcAlignmentReader();
				ifcAlignmentReader.ReadFile(fileName);
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				CivilDocument activeDocument = CivilApplication.ActiveDocument;
				IfcBase[] entityList = ifcAlignmentReader._entityList;
				int num = ifcAlignmentReader.CountIfcEntities(fileName);
				int num2 = 1;
				int num3 = 1;
				double compareX = 0.0;
				double compareY = 0.0;
				int i = 1;
				while (i <= num)
				{
					if (!(entityList[i].GetType() == typeof(IfcAlignment)))
					{
						goto IL_7B7;
					}
					if (import.checkBox2.Checked)
					{
						IfcAlignment ifcAlignment = (IfcAlignment)entityList[i];
						string text;
						if (ifcAlignment.o_Name == null)
						{
							if (ifcAlignment.o_Description == null)
							{
								text = "Imported Alignment" + num3.ToString();
							}
							else
							{
								text = ifcAlignment.o_Description._value;
							}
						}
						else
						{
							text = ifcAlignment.o_Name._value;
						}
						ObjectId objectId = Alignment.Create(activeDocument, text, "", "C-ROAD", "Proposed", "All Labels");
						using (Transaction transaction = database.TransactionManager.StartTransaction())
						{
							Alignment alignment = (Alignment)transaction.GetObject(objectId, 1);
							IfcAlignmentCurve ifcAlignmentCurve = (IfcAlignmentCurve)ifcAlignment.m_Axis;
							IfcAlignment2DHorizontal horizontal = ifcAlignmentCurve.m_Horizontal;
							IfcAlignment2DVertical o_Vertical = ifcAlignmentCurve.o_Vertical;
							int num4 = 0;
							int num5 = 1;
							foreach (IfcAlignment2DHorizontalSegment ifcAlignment2DHorizontalSegment in horizontal.m_Segments)
							{
								if (ifcAlignment2DHorizontalSegment.m_CurveGeometry.GetType() == typeof(IfcLineSegment2D))
								{
									IfcLineSegment2D ifcLineSegment2D = (IfcLineSegment2D)ifcAlignment2DHorizontalSegment.m_CurveGeometry;
									Point3d point3d;
									if (num4 > 0)
									{
										point3d = C3DIfcAlignmentAddIn.CheckForVicintiy(compareX, compareY, ifcLineSegment2D.m_StartPoint);
									}
									else
									{
										point3d = C3DIfcAlignmentAddIn.ConvertIfcPoint2D(ifcLineSegment2D.m_StartPoint);
									}
									AlignmentLine alignmentLine = alignment.Entities.AddFixedLine(num4, point3d, C3DIfcAlignmentAddIn.CalculateLinePoint(ifcLineSegment2D, 1.0));
									num4++;
									compareX = alignmentLine.EndPoint.X;
									compareY = alignmentLine.EndPoint.Y;
								}
								else if (ifcAlignment2DHorizontalSegment.m_CurveGeometry.GetType() == typeof(IfcCircularArcSegment2D))
								{
									IfcCircularArcSegment2D ifcCircularArcSegment2D = (IfcCircularArcSegment2D)ifcAlignment2DHorizontalSegment.m_CurveGeometry;
									Point3d point3d;
									if (num4 > 0)
									{
										point3d = C3DIfcAlignmentAddIn.CheckForVicintiy(compareX, compareY, ifcCircularArcSegment2D.m_StartPoint);
									}
									else
									{
										point3d = C3DIfcAlignmentAddIn.ConvertIfcPoint2D(ifcCircularArcSegment2D.m_StartPoint);
									}
									AlignmentArc alignmentArc = alignment.Entities.AddFixedCurve(num4, point3d, C3DIfcAlignmentAddIn.GetArcPoint(ifcCircularArcSegment2D, 0.5), C3DIfcAlignmentAddIn.GetArcPoint(ifcCircularArcSegment2D, 1.0));
									num4++;
									compareX = alignmentArc.EndPoint.X;
									compareY = alignmentArc.EndPoint.Y;
								}
								else if (!(ifcAlignment2DHorizontalSegment.m_CurveGeometry.GetType() == typeof(IfcClothoidalArcSegment2D)) && ifcAlignment2DHorizontalSegment.m_CurveGeometry.GetType() == typeof(IfcTransitionCurveSegment2D))
								{
									IfcTransitionCurveSegment2D ifcTransitionCurveSegment2D = (IfcTransitionCurveSegment2D)ifcAlignment2DHorizontalSegment.m_CurveGeometry;
									float num6 = 0f;
									double num7;
									if (ifcTransitionCurveSegment2D.o_EndRadius == null)
									{
										num7 = (double)(1f / num6);
									}
									else
									{
										num7 = ifcTransitionCurveSegment2D.o_EndRadius._value;
									}
									if (ifcTransitionCurveSegment2D.m_TransitionCurveType._value == 2)
									{
										AlignmentSpiral alignmentSpiral = alignment.Entities.AddFloatSpiral(num4, num7, ifcTransitionCurveSegment2D.m_SegmentLength._value._value, C3DIfcAlignmentAddIn.CheckTheCivilTime(ifcTransitionCurveSegment2D.m_IsStartRadiusCCW._value), 256);
										num5++;
										compareX = alignmentSpiral.EndPoint.X;
										compareY = alignmentSpiral.EndPoint.Y;
									}
									else if (ifcTransitionCurveSegment2D.m_TransitionCurveType._value == 1)
									{
										AlignmentSpiral alignmentSpiral2 = alignment.Entities.AddFloatSpiral(num4, num7, ifcTransitionCurveSegment2D.m_SegmentLength._value._value, C3DIfcAlignmentAddIn.CheckTheCivilTime(ifcTransitionCurveSegment2D.m_IsStartRadiusCCW._value), 259);
										num5++;
										compareX = alignmentSpiral2.EndPoint.X;
										compareY = alignmentSpiral2.EndPoint.Y;
									}
									else if (ifcTransitionCurveSegment2D.m_TransitionCurveType._value == 5)
									{
										AlignmentSpiral alignmentSpiral3 = alignment.Entities.AddFloatSpiral(num4, num7, ifcTransitionCurveSegment2D.m_SegmentLength._value._value, C3DIfcAlignmentAddIn.CheckTheCivilTime(ifcTransitionCurveSegment2D.m_IsStartRadiusCCW._value), 261);
										num5++;
										compareX = alignmentSpiral3.EndPoint.X;
										compareY = alignmentSpiral3.EndPoint.Y;
									}
									else if (ifcTransitionCurveSegment2D.m_TransitionCurveType._value != 3)
									{
										if (ifcTransitionCurveSegment2D.m_TransitionCurveType._value == null)
										{
											AlignmentSpiral alignmentSpiral4 = alignment.Entities.AddFloatSpiral(num4, num7, ifcTransitionCurveSegment2D.m_SegmentLength._value._value, C3DIfcAlignmentAddIn.CheckTheCivilTime(ifcTransitionCurveSegment2D.m_IsStartRadiusCCW._value), 262);
											num5++;
											compareX = alignmentSpiral4.EndPoint.X;
											compareY = alignmentSpiral4.EndPoint.Y;
										}
										else if (ifcTransitionCurveSegment2D.m_TransitionCurveType._value == 4)
										{
											AlignmentSpiral alignmentSpiral5 = alignment.Entities.AddFloatSpiral(num4, num7, ifcTransitionCurveSegment2D.m_SegmentLength._value._value, C3DIfcAlignmentAddIn.CheckTheCivilTime(ifcTransitionCurveSegment2D.m_IsStartRadiusCCW._value), 260);
											num5++;
											compareX = alignmentSpiral5.EndPoint.X;
											compareY = alignmentSpiral5.EndPoint.Y;
										}
									}
									num4++;
								}
							}
							uint num8 = 0u;
							if (o_Vertical != null)
							{
								ObjectId layerId = alignment.LayerId;
								ObjectId objectId2 = activeDocument.Styles.ProfileStyles[0];
								ObjectId objectId3 = activeDocument.Styles.LabelSetStyles.ProfileLabelSetStyles[0];
								ObjectId objectId4 = Profile.CreateByLayout("Profile_to_" + text, objectId, layerId, objectId2, objectId3);
								Point3d point3d2;
								point3d2..ctor(100.0, 100.0, 0.0);
								ObjectId objectId5 = activeDocument.Styles.ProfileViewBandSetStyles[0];
								ProfileView.Create(activeDocument, "Profile View to " + text, objectId5, objectId, point3d2);
								Profile profile = (Profile)transaction.GetObject(objectId4, 1);
								foreach (IfcAlignment2DVerticalSegment ifcAlignment2DVerticalSegment in o_Vertical.m_Segments)
								{
									if (ifcAlignment2DVerticalSegment.GetType() == typeof(IfcAlignment2DVerSegLine))
									{
										IfcAlignment2DVerSegLine ifcAlignment2DVerSegLine = (IfcAlignment2DVerSegLine)ifcAlignment2DVerticalSegment;
										Point2d point2d;
										point2d..ctor(ifcAlignment2DVerSegLine.m_StartDistAlong._value, ifcAlignment2DVerSegLine.m_StartHeight._value);
										Point2d point2d2 = C3DIfcAlignmentAddIn.CalculateTangentPoint(ifcAlignment2DVerSegLine, 1.0);
										profile.Entities.AddFixedTangent(point2d, point2d2);
										num8 += 1u;
									}
									else if (ifcAlignment2DVerticalSegment.GetType() == typeof(IfcAlignment2DVerSegParabolicArc))
									{
										Point2d point2d3 = C3DIfcAlignmentAddIn.CalculateVerParabolaPoint((IfcAlignment2DVerSegParabolicArc)ifcAlignment2DVerticalSegment, 1.0);
										profile.Entities.AddFixedSymmetricParabolaByEntityEndAndThroughPoint(num8, point2d3);
										num8 += 1u;
									}
									else if (ifcAlignment2DVerticalSegment.GetType() == typeof(IfcAlignment2DVerSegCircularArc))
									{
										IfcAlignment2DVerSegCircularArc ifcAlignment2DVerSegCircularArc = (IfcAlignment2DVerSegCircularArc)ifcAlignment2DVerticalSegment;
										num4++;
									}
								}
							}
							transaction.Commit();
							goto IL_8E3;
						}
						goto IL_7B7;
					}
					IL_8E3:
					i++;
					continue;
					IL_7B7:
					if (entityList[i].GetType() == typeof(IfcTriangulatedFaceSet) && import.checkBox1.Checked)
					{
						string text2 = "Imported_TIN_Surface_" + num2;
						num2++;
						List<List<IfcLengthMeasure>> coordList = ((IfcTriangulatedFaceSet)entityList[i]).m_Coordinates.m_CoordList;
						using (Transaction transaction2 = database.TransactionManager.StartTransaction())
						{
							ObjectId objectId6 = activeDocument.Styles.SurfaceStyles["Contours and Triangles"];
							if (new ObjectIdCollection() != null)
							{
								ObjectId objectId7 = TinSurface.Create(text2, objectId6);
								TinSurface tinSurface = transaction2.GetObject(objectId7, 1) as TinSurface;
								for (int j = 0; j <= coordList.Count - 1; j++)
								{
									List<IfcLengthMeasure> list = coordList[j];
									double value = list[0]._value;
									double value2 = list[1]._value;
									double value3 = list[2]._value;
									Point3d point3d3;
									point3d3..ctor(value, value2, value3);
									j += simplifier;
									tinSurface.AddVertex(point3d3);
								}
							}
							transaction2.Commit();
						}
						goto IL_8E3;
					}
					goto IL_8E3;
				}
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003BC4 File Offset: 0x00001DC4
		[CommandMethod("ifc", 2097152)]
		public void Main()
		{
			new License().ShowDialog();
			RibbonTab ribbonTab = ComponentManager.Ribbon.FindTab("CIVIL.ID_Civil3DAddins");
			if (ribbonTab != null && ribbonTab.Panels != null)
			{
				foreach (RibbonPanel ribbonPanel in ribbonTab.Panels)
				{
					if (ribbonPanel.UID == "UID_IfcPanel")
					{
						RibbonPanel item = ribbonPanel;
						ribbonTab.Panels.Remove(item);
						break;
					}
				}
			}
			RibbonPanel ribbonPanel2 = new RibbonPanel
			{
				UID = "UID_IfcPanel",
				Id = "ID_IfcPanel"
			};
			RibbonPanelSource ribbonPanelSource = new RibbonPanelSource
			{
				Id = "ID_IfcPanelSource",
				Name = "IfcPanelSource",
				Title = "IFC Alignment v1.1"
			};
			ribbonPanel2.Source = ribbonPanelSource;
			RibbonButton ribbonButton = new RibbonButton
			{
				Name = "Export Ifc...",
				Text = "Ifc Export",
				GroupLocation = 3,
				ResizeStyle = 2,
				Orientation = Orientation.Horizontal,
				ShowText = false,
				CommandHandler = new C3DIfcAlignmentAddIn.ExportCmdHandler(),
				Id = "ID_TestButton",
				ShowImage = true,
				LargeImage = this.GetBitmap("Export_Icon.png"),
				Image = this.GetBitmap("Export_Icon.png"),
				Size = 1
			};
			RibbonToolTip toolTip = new RibbonToolTip
			{
				Command = "IFC",
				Title = "Ifc-Export",
				Content = "This Add-in let's you export your current .dwg-file to an IFC 4 (.ifc) File.",
				ExpandedContent = "In the dialog box, navigate to the file directory you want to save your file."
			};
			ribbonButton.ToolTip = toolTip;
			RibbonButton ribbonButton2 = new RibbonButton
			{
				Name = "Import Ifc...",
				Text = "Ifc Import",
				CommandParameter = "_.IFCImportTest ",
				GroupLocation = 3,
				ResizeStyle = 2,
				Orientation = Orientation.Horizontal,
				ShowText = false,
				Id = "ID_TestButton",
				ShowImage = true,
				CommandHandler = new C3DIfcAlignmentAddIn.ImportCmdHandler(),
				LargeImage = this.GetBitmap("Import_Icon.png"),
				Image = this.GetBitmap("Import_Icon.png"),
				Size = 1
			};
			RibbonToolTip toolTip2 = new RibbonToolTip
			{
				Command = "IFC",
				Title = "Ifc-Import",
				Content = "This Add-in let's you import a IFC 4 (.ifc) File to your current drawing.",
				ExpandedContent = "In the dialog box, navigate to the file directory your IFC-File ist stored."
			};
			ribbonButton2.ToolTip = toolTip2;
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton
			{
				Text = "Ifc Add-in",
				ShowText = true,
				Size = 1,
				Name = "Ifc Add-in"
			};
			ribbonSplitButton.Items.Add(ribbonButton);
			ribbonSplitButton.Items.Add(ribbonButton2);
			if (ribbonTab != null)
			{
				if (ribbonTab.Panels != null)
				{
					ribbonTab.Panels.Add(ribbonPanel2);
				}
				ribbonTab.IsActive = true;
			}
			ribbonPanelSource.Items.Add(ribbonSplitButton);
		}

		// Token: 0x02000009 RID: 9
		public class ExportCmdHandler : ICommand
		{
			// Token: 0x0600004B RID: 75 RVA: 0x000067C0 File Offset: 0x000049C0
			public bool CanExecute(object parameter)
			{
				return true;
			}

			// Token: 0x14000001 RID: 1
			// (add) Token: 0x0600004C RID: 76 RVA: 0x000067C4 File Offset: 0x000049C4
			// (remove) Token: 0x0600004D RID: 77 RVA: 0x000067FC File Offset: 0x000049FC
			public event EventHandler CanExecuteChanged;

			// Token: 0x0600004E RID: 78 RVA: 0x00006834 File Offset: 0x00004A34
			public void Execute(object parameter)
			{
				if (parameter is RibbonButton)
				{
					Export export = new Export();
					export.ShowDialog();
					bool @checked = export.checkBox1.Checked;
					bool checked2 = export.checkBox2.Checked;
					bool buttonWasClicked = export.buttonWasClicked;
					IfcPerson ifcPerson = new IfcPerson
					{
						o_FamilyName = new IfcLabel
						{
							_value = export.personLastName.Text
						},
						o_GivenName = new IfcLabel
						{
							_value = export.personFirstName.Text
						}
					};
					bool? flag = new bool?(false);
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					if (buttonWasClicked)
					{
						saveFileDialog = new SaveFileDialog
						{
							FileName = "ifcAlignment",
							DefaultExt = ".ifc",
							Filter = "Ifc Files (.ifc)|*.ifc"
						};
						flag = saveFileDialog.ShowDialog();
					}
					if (flag == true)
					{
						Database database = Application.DocumentManager.MdiActiveDocument.Database;
						CivilDocument activeDocument = CivilApplication.ActiveDocument;
						using (Transaction transaction = database.TransactionManager.StartTransaction())
						{
							IfcWriter ifcWriter = new IfcWriter();
							IfcOrganization ifcOrganization = new IfcOrganization
							{
								m_Name = new IfcLabel
								{
									_value = "FlixFixCoding"
								}
							};
							IfcApplication ifcApplication = new IfcApplication
							{
								m_ApplicationDeveloper = ifcOrganization,
								m_ApplicationFullName = new IfcLabel
								{
									_value = "Autodesk Civil 3D"
								},
								m_ApplicationIdentifier = new IfcIdentifier
								{
									_value = "C3D"
								},
								m_Version = new IfcLabel
								{
									_value = "1.0"
								}
							};
							IfcPersonAndOrganization ifcPersonAndOrganization = new IfcPersonAndOrganization
							{
								m_TheOrganization = ifcOrganization,
								m_ThePerson = ifcPerson
							};
							IfcDimensionalExponents ifcDimensionalExponents = new IfcDimensionalExponents
							{
								m_AmountOfSubstanceExponent = 0,
								m_ElectricCurrentExponent = 0,
								m_LengthExponent = 0,
								m_LuminousIntensityExponent = 0,
								m_MassExponent = 0,
								m_ThermodynamicTemperatureExponent = 0,
								m_TimeExponent = 0
							};
							IfcSIUnit ifcSIUnit = new IfcSIUnit
							{
								m_Name = new IfcSIUnitName
								{
									_value = 15
								},
								m_Dimensions = ifcDimensionalExponents,
								m_UnitType = new IfcUnitEnum
								{
									_value = 15
								}
							};
							IfcSIUnit ifcSIUnit2 = new IfcSIUnit
							{
								m_Name = new IfcSIUnitName
								{
									_value = 20
								},
								m_Dimensions = ifcDimensionalExponents,
								m_UnitType = new IfcUnitEnum
								{
									_value = 21
								}
							};
							IfcSIUnit ifcSIUnit3 = new IfcSIUnit
							{
								m_Name = new IfcSIUnitName
								{
									_value = 24
								},
								m_Dimensions = ifcDimensionalExponents,
								m_UnitType = new IfcUnitEnum
								{
									_value = 2
								}
							};
							IfcSIUnit ifcSIUnit4 = new IfcSIUnit
							{
								m_Name = new IfcSIUnitName
								{
									_value = 4
								},
								m_Dimensions = ifcDimensionalExponents,
								m_UnitType = new IfcUnitEnum
								{
									_value = 28
								}
							};
							IfcUnit item = new IfcUnit
							{
								_value = ifcSIUnit
							};
							IfcUnit item2 = new IfcUnit
							{
								_value = ifcSIUnit2
							};
							IfcUnit item3 = new IfcUnit
							{
								_value = ifcSIUnit3
							};
							IfcUnit item4 = new IfcUnit
							{
								_value = ifcSIUnit4
							};
							IfcUnitAssignment ifcUnitAssignment = new IfcUnitAssignment
							{
								m_Units = new List<IfcUnit>
								{
									item,
									item2,
									item3,
									item4
								}
							};
							IfcProject ifcProject = new IfcProject
							{
								m_GlobalId = C3DIfcAlignmentAddIn.CreateUniqueId(),
								o_Name = new IfcLabel
								{
									_value = Application.DocumentManager.MdiActiveDocument.Database.ProjectName
								},
								o_UnitsInContext = ifcUnitAssignment
							};
							IfcCartesianPoint ifcCartesianPoint = C3DIfcAlignmentAddIn.CreateIfcPoint3D(0.0, 0.0, 0.0);
							IfcAxis2Placement3D ifcAxis2Placement3D = new IfcAxis2Placement3D
							{
								m_Location = ifcCartesianPoint
							};
							IfcLocalPlacement ifcLocalPlacement = new IfcLocalPlacement
							{
								m_RelativePlacement = new IfcAxis2Placement
								{
									_value = ifcAxis2Placement3D
								}
							};
							ifcWriter.insertEntity(ifcPerson);
							ifcWriter.insertEntity(ifcOrganization);
							ifcWriter.insertEntity(ifcApplication);
							ifcWriter.insertEntity(ifcPersonAndOrganization);
							ifcWriter.insertEntity(ifcDimensionalExponents);
							ifcWriter.insertEntity(ifcUnitAssignment);
							ifcWriter.insertEntity(ifcSIUnit);
							ifcWriter.insertEntity(ifcSIUnit2);
							ifcWriter.insertEntity(ifcSIUnit3);
							ifcWriter.insertEntity(ifcSIUnit4);
							ifcWriter.insertEntity(ifcProject);
							ifcWriter.insertEntity(ifcCartesianPoint);
							ifcWriter.insertEntity(ifcAxis2Placement3D);
							ifcWriter.insertEntity(ifcLocalPlacement);
							foreach (object obj in CivilApplication.ActiveDocument.GetSiteIds())
							{
								Site site = ((ObjectId)obj).GetObject(0) as Site;
								IfcSite ifcSite = new IfcSite
								{
									m_GlobalId = C3DIfcAlignmentAddIn.CreateUniqueId(),
									o_ObjectPlacement = ifcLocalPlacement
								};
								if (site != null && site.Name != null)
								{
									ifcSite.o_Name = new IfcLabel
									{
										_value = site.Name
									};
								}
								if (site != null && site.Description != null)
								{
									ifcSite.o_Description = new IfcText
									{
										_value = site.Description
									};
								}
								ifcWriter.insertEntity(ifcSite);
							}
							IfcSIUnit ifcSIUnit5 = new IfcSIUnit
							{
								m_Name = new IfcSIUnitName
								{
									_value = 15
								},
								m_Dimensions = ifcDimensionalExponents,
								m_UnitType = new IfcUnitEnum
								{
									_value = 15
								}
							};
							IfcProjectedCRS ifcProjectedCRS = new IfcProjectedCRS
							{
								o_Description = new IfcText
								{
									_value = export.coorDesc.Text
								},
								m_Name = new IfcLabel
								{
									_value = export.coorName.Text
								},
								o_MapUnit = ifcSIUnit5,
								o_GeodeticDatum = new IfcIdentifier
								{
									_value = export.coorGeoDate.Text
								},
								o_VerticalDatum = new IfcIdentifier
								{
									_value = export.coorVertDate.Text
								},
								o_MapProjection = new IfcIdentifier
								{
									_value = export.coorMapProj.Text
								},
								o_MapZone = new IfcIdentifier
								{
									_value = export.coorMapZone.Text
								}
							};
							ifcWriter.insertEntity(ifcProjectedCRS);
							ifcWriter.insertEntity(ifcSIUnit5);
							if (@checked)
							{
								foreach (object obj2 in activeDocument.GetSurfaceIds())
								{
									ObjectId objectId = (ObjectId)obj2;
									Surface surface = (Surface)transaction.GetObject(objectId, 0);
									if (surface is TinSurface)
									{
										IfcGeometricRepresentationContext ifcGeometricRepresentationContext = new IfcGeometricRepresentationContext
										{
											m_WorldCoordinateSystem = new IfcAxis2Placement
											{
												_value = ifcAxis2Placement3D
											},
											m_CoordinateSpaceDimension = new IfcDimensionCount
											{
												_value = 3
											},
											o_ContextType = new IfcLabel
											{
												_value = "Surface"
											}
										};
										ifcWriter.insertEntity(ifcGeometricRepresentationContext);
										TinSurface tinSurface = surface as TinSurface;
										IfcTriangulatedFaceSet ifcTriangulatedFaceSet = new IfcTriangulatedFaceSet
										{
											m_CoordIndex = new List<List<IfcPositiveInteger>>(),
											o_Closed = new IfcBoolean
											{
												_value = false
											}
										};
										ifcWriter.insertEntity(ifcTriangulatedFaceSet);
										IfcCartesianPointList3D ifcCartesianPointList3D = new IfcCartesianPointList3D
										{
											m_CoordList = new List<List<IfcLengthMeasure>>()
										};
										ifcTriangulatedFaceSet.m_Coordinates = ifcCartesianPointList3D;
										ifcWriter.insertEntity(ifcCartesianPointList3D);
										TinSurfaceTriangleCollection triangles = tinSurface.GetTriangles(false);
										int num = 1;
										foreach (TinSurfaceTriangle tinSurfaceTriangle in triangles)
										{
											List<IfcLengthMeasure> list = new List<IfcLengthMeasure>();
											List<IfcPositiveInteger> list2 = new List<IfcPositiveInteger>();
											IfcLengthMeasure item5 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex1.Location.X
											};
											IfcLengthMeasure item6 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex1.Location.Y
											};
											IfcLengthMeasure item7 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex1.Location.Z
											};
											list.Add(item5);
											list.Add(item6);
											list.Add(item7);
											list2.Add(new IfcPositiveInteger
											{
												_value = new IfcInteger
												{
													_value = num
												}
											});
											num++;
											List<IfcLengthMeasure> list3 = new List<IfcLengthMeasure>();
											IfcLengthMeasure item8 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex2.Location.X
											};
											IfcLengthMeasure item9 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex2.Location.Y
											};
											IfcLengthMeasure item10 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex2.Location.Z
											};
											list3.Add(item8);
											list3.Add(item9);
											list3.Add(item10);
											list2.Add(new IfcPositiveInteger
											{
												_value = new IfcInteger
												{
													_value = num
												}
											});
											num++;
											List<IfcLengthMeasure> list4 = new List<IfcLengthMeasure>();
											IfcLengthMeasure item11 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex3.Location.X
											};
											IfcLengthMeasure item12 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex3.Location.Y
											};
											IfcLengthMeasure item13 = new IfcLengthMeasure
											{
												_value = tinSurfaceTriangle.Vertex3.Location.Z
											};
											list4.Add(item11);
											list4.Add(item12);
											list4.Add(item13);
											list2.Add(new IfcPositiveInteger
											{
												_value = new IfcInteger
												{
													_value = num
												}
											});
											num++;
											ifcCartesianPointList3D.m_CoordList.Add(list);
											ifcCartesianPointList3D.m_CoordList.Add(list3);
											ifcCartesianPointList3D.m_CoordList.Add(list4);
											ifcTriangulatedFaceSet.m_CoordIndex.Add(list2);
										}
										IfcShapeRepresentation ifcShapeRepresentation = new IfcShapeRepresentation
										{
											m_ContextOfItems = ifcGeometricRepresentationContext,
											m_Items = new List<IfcRepresentationItem>()
										};
										ifcShapeRepresentation.m_Items.Add(ifcTriangulatedFaceSet);
										ifcWriter.insertEntity(ifcShapeRepresentation);
										IfcProductDefinitionShape ifcProductDefinitionShape = new IfcProductDefinitionShape
										{
											m_Representations = new List<IfcRepresentation>()
										};
										ifcProductDefinitionShape.m_Representations.Add(ifcShapeRepresentation);
										ifcWriter.insertEntity(ifcProductDefinitionShape);
										IfcGeographicElement ifcGeographicElement = new IfcGeographicElement
										{
											m_GlobalId = C3DIfcAlignmentAddIn.CreateUniqueId(),
											o_ObjectPlacement = ifcLocalPlacement,
											o_Representation = ifcProductDefinitionShape
										};
										ifcWriter.insertEntity(ifcGeographicElement);
									}
								}
							}
							if (checked2)
							{
								foreach (object obj3 in activeDocument.GetAlignmentIds())
								{
									ObjectId objectId2 = (ObjectId)obj3;
									Alignment alignment = (Alignment)transaction.GetObject(objectId2, 0);
									IfcAlignment ifcAlignment = new IfcAlignment
									{
										m_GlobalId = C3DIfcAlignmentAddIn.CreateUniqueId(),
										o_Name = new IfcLabel
										{
											_value = alignment.Name
										},
										o_ObjectPlacement = ifcLocalPlacement
									};
									ifcWriter.insertEntity(ifcAlignment);
									IfcAlignmentCurve ifcAlignmentCurve = new IfcAlignmentCurve();
									ifcAlignment.m_Axis = ifcAlignmentCurve;
									ifcWriter.insertEntity(ifcAlignmentCurve);
									IfcAlignment2DHorizontal ifcAlignment2DHorizontal = new IfcAlignment2DHorizontal
									{
										o_StartDistAlong = new IfcLengthMeasure
										{
											_value = 0.0
										},
										m_Segments = new List<IfcAlignment2DHorizontalSegment>()
									};
									ifcAlignmentCurve.m_Horizontal = ifcAlignment2DHorizontal;
									ifcWriter.insertEntity(ifcAlignment2DHorizontal);
									foreach (AlignmentEntity alignmentEntity in C3DIfcAlignmentAddIn.SortC3DAlignmentEntities(alignment))
									{
										int subEntityCount = alignmentEntity.SubEntityCount;
										for (int i = 0; i <= subEntityCount - 1; i++)
										{
											AlignmentSubEntity alignmentSubEntity = alignmentEntity[i];
											switch (alignmentSubEntity.SubEntityType)
											{
											case 0:
											{
												AlignmentSubEntityLine alignmentSubEntityLine = (AlignmentSubEntityLine)alignmentSubEntity;
												IfcAlignment2DHorizontalSegment ifcAlignment2DHorizontalSegment = new IfcAlignment2DHorizontalSegment
												{
													o_TangentialContinuity = C3DIfcAlignmentAddIn.CheckTangential(alignmentEntity.Constraint1.ToString())
												};
												IfcCartesianPoint ifcCartesianPoint2 = C3DIfcAlignmentAddIn.CreateIfcPoint2D(alignmentSubEntityLine.StartPoint.X, alignmentSubEntityLine.StartPoint.Y);
												IfcLineSegment2D ifcLineSegment2D = new IfcLineSegment2D
												{
													m_StartDirection = C3DIfcAlignmentAddIn.GetIfcDirection(alignmentSubEntityLine.Direction),
													m_SegmentLength = new IfcPositiveLengthMeasure
													{
														_value = new IfcLengthMeasure
														{
															_value = alignmentSubEntityLine.Length
														}
													},
													m_StartPoint = ifcCartesianPoint2
												};
												ifcAlignment2DHorizontalSegment.m_CurveGeometry = ifcLineSegment2D;
												ifcAlignment2DHorizontal.m_Segments.Add(ifcAlignment2DHorizontalSegment);
												ifcWriter.insertEntity(ifcAlignment2DHorizontalSegment);
												ifcWriter.insertEntity(ifcLineSegment2D);
												ifcWriter.insertEntity(ifcCartesianPoint2);
												break;
											}
											case 1:
											{
												AlignmentSubEntityArc alignmentSubEntityArc = (AlignmentSubEntityArc)alignmentSubEntity;
												IfcAlignment2DHorizontalSegment ifcAlignment2DHorizontalSegment2 = new IfcAlignment2DHorizontalSegment
												{
													o_TangentialContinuity = C3DIfcAlignmentAddIn.CheckTangential(alignmentEntity.Constraint1.ToString())
												};
												IfcCartesianPoint ifcCartesianPoint3 = C3DIfcAlignmentAddIn.CreateIfcPoint2D(alignmentSubEntityArc.StartPoint.X, alignmentSubEntityArc.StartPoint.Y);
												IfcCircularArcSegment2D ifcCircularArcSegment2D = new IfcCircularArcSegment2D
												{
													m_IsCCW = C3DIfcAlignmentAddIn.CheckTheIfcTime(alignmentSubEntityArc.Clockwise.ToString()),
													m_Radius = new IfcPositiveLengthMeasure
													{
														_value = new IfcLengthMeasure
														{
															_value = alignmentSubEntityArc.Radius
														}
													},
													m_SegmentLength = new IfcPositiveLengthMeasure
													{
														_value = new IfcLengthMeasure
														{
															_value = alignmentSubEntityArc.Length
														}
													},
													m_StartDirection = C3DIfcAlignmentAddIn.GetIfcDirection(alignmentSubEntityArc.StartDirection),
													m_StartPoint = ifcCartesianPoint3
												};
												ifcAlignment2DHorizontalSegment2.m_CurveGeometry = ifcCircularArcSegment2D;
												ifcAlignment2DHorizontal.m_Segments.Add(ifcAlignment2DHorizontalSegment2);
												ifcWriter.insertEntity(ifcAlignment2DHorizontalSegment2);
												ifcWriter.insertEntity(ifcCircularArcSegment2D);
												ifcWriter.insertEntity(ifcCartesianPoint3);
												break;
											}
											case 2:
											{
												AlignmentSubEntitySpiral alignmentSubEntitySpiral = (AlignmentSubEntitySpiral)alignmentSubEntity;
												IfcAlignment2DHorizontalSegment ifcAlignment2DHorizontalSegment3 = new IfcAlignment2DHorizontalSegment
												{
													o_TangentialContinuity = C3DIfcAlignmentAddIn.CheckTangential(alignmentEntity.Constraint1.ToString())
												};
												IfcCartesianPoint ifcCartesianPoint4 = C3DIfcAlignmentAddIn.CreateIfcPoint2D(alignmentSubEntitySpiral.StartPoint.X, alignmentSubEntitySpiral.StartPoint.Y);
												IfcTransitionCurveSegment2D ifcTransitionCurveSegment2D = new IfcTransitionCurveSegment2D
												{
													m_SegmentLength = new IfcPositiveLengthMeasure
													{
														_value = new IfcLengthMeasure
														{
															_value = alignmentSubEntitySpiral.Length
														}
													},
													m_StartPoint = ifcCartesianPoint4,
													m_StartDirection = C3DIfcAlignmentAddIn.GetIfcDirection(alignmentSubEntitySpiral.StartDirection),
													m_IsEndRadiusCCW = C3DIfcAlignmentAddIn.CheckTheIfcTime(alignmentSubEntitySpiral.Direction.ToString()),
													m_IsStartRadiusCCW = C3DIfcAlignmentAddIn.CheckTheIfcTime(alignmentSubEntitySpiral.Direction.ToString()),
													m_TransitionCurveType = C3DIfcAlignmentAddIn.GetIfcSpiralType(alignmentSubEntitySpiral.SpiralDefinition),
													o_StartRadius = new IfcLengthMeasure
													{
														_value = alignmentSubEntitySpiral.RadiusIn
													},
													o_EndRadius = new IfcLengthMeasure
													{
														_value = alignmentSubEntitySpiral.RadiusOut
													}
												};
												ifcAlignment2DHorizontalSegment3.m_CurveGeometry = ifcTransitionCurveSegment2D;
												ifcAlignment2DHorizontal.m_Segments.Add(ifcAlignment2DHorizontalSegment3);
												ifcWriter.insertEntity(ifcAlignment2DHorizontalSegment3);
												ifcWriter.insertEntity(ifcTransitionCurveSegment2D);
												ifcWriter.insertEntity(ifcCartesianPoint4);
												break;
											}
											}
										}
									}
									foreach (object obj4 in alignment.GetProfileIds())
									{
										ObjectId objectId3 = (ObjectId)obj4;
										Profile profile = (Profile)transaction.GetObject(objectId3, 0);
										if (!(profile.StyleName == "Existing Ground Profile"))
										{
											IfcAlignment2DVertical ifcAlignment2DVertical = new IfcAlignment2DVertical
											{
												m_Segments = new List<IfcAlignment2DVerticalSegment>()
											};
											ifcAlignmentCurve.o_Vertical = ifcAlignment2DVertical;
											ifcWriter.insertEntity(ifcAlignment2DVertical);
											foreach (ProfileEntity profileEntity in C3DIfcAlignmentAddIn.SortC3DProfileEntities(profile))
											{
												switch (profileEntity.EntityType)
												{
												case 257:
												{
													ProfileTangent profileTangent = (ProfileTangent)profileEntity;
													IfcAlignment2DVerSegLine ifcAlignment2DVerSegLine = new IfcAlignment2DVerSegLine
													{
														m_StartDistAlong = new IfcLengthMeasure
														{
															_value = profileTangent.StartStation
														},
														m_HorizontalLength = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileTangent.Length
															}
														},
														m_StartGradient = new IfcRatioMeasure
														{
															_value = profileTangent.Grade
														},
														m_StartHeight = new IfcLengthMeasure
														{
															_value = profileTangent.StartElevation
														}
													};
													ifcAlignment2DVertical.m_Segments.Add(ifcAlignment2DVerSegLine);
													ifcWriter.insertEntity(ifcAlignment2DVerSegLine);
													break;
												}
												case 258:
												{
													ProfileCircular profileCircular = (ProfileCircular)profileEntity;
													IfcAlignment2DVerSegCircularArc ifcAlignment2DVerSegCircularArc = new IfcAlignment2DVerSegCircularArc
													{
														m_HorizontalLength = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileCircular.Length
															}
														},
														m_StartHeight = new IfcLengthMeasure
														{
															_value = profileCircular.StartElevation
														},
														m_StartDistAlong = new IfcLengthMeasure
														{
															_value = profileCircular.StartStation
														},
														m_StartGradient = new IfcRatioMeasure
														{
															_value = profileCircular.GradeIn
														},
														m_Radius = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileCircular.Radius
															}
														},
														m_IsConvex = C3DIfcAlignmentAddIn.CheckForConvexity(profileEntity)
													};
													ifcAlignment2DVertical.m_Segments.Add(ifcAlignment2DVerSegCircularArc);
													ifcWriter.insertEntity(ifcAlignment2DVerSegCircularArc);
													break;
												}
												case 259:
												{
													ProfileParabolaSymmetric profileParabolaSymmetric = (ProfileParabolaSymmetric)profileEntity;
													IfcAlignment2DVerSegParabolicArc ifcAlignment2DVerSegParabolicArc = new IfcAlignment2DVerSegParabolicArc
													{
														m_HorizontalLength = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileParabolaSymmetric.Length
															}
														},
														m_StartHeight = new IfcLengthMeasure
														{
															_value = profileParabolaSymmetric.StartElevation
														},
														m_StartGradient = new IfcRatioMeasure
														{
															_value = profileParabolaSymmetric.GradeIn
														},
														m_StartDistAlong = new IfcLengthMeasure
														{
															_value = profileParabolaSymmetric.StartStation
														},
														m_ParabolaConstant = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileParabolaSymmetric.Radius
															}
														}
													};
													ifcAlignment2DVerSegParabolicArc.m_IsConvex = C3DIfcAlignmentAddIn.CheckForConvexity(profileEntity);
													ifcAlignment2DVertical.m_Segments.Add(ifcAlignment2DVerSegParabolicArc);
													ifcWriter.insertEntity(ifcAlignment2DVerSegParabolicArc);
													break;
												}
												case 260:
												{
													ProfileParabolaAsymmetric profileParabolaAsymmetric = (ProfileParabolaAsymmetric)profileEntity;
													IfcAlignment2DVerSegParabolicArc ifcAlignment2DVerSegParabolicArc2 = new IfcAlignment2DVerSegParabolicArc
													{
														m_HorizontalLength = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileParabolaAsymmetric.AsymmetricLength1
															}
														},
														m_StartHeight = new IfcLengthMeasure
														{
															_value = profileParabolaAsymmetric.StartElevation
														},
														m_StartGradient = new IfcRatioMeasure
														{
															_value = profileParabolaAsymmetric.GradeIn
														},
														m_StartDistAlong = new IfcLengthMeasure
														{
															_value = profileParabolaAsymmetric.StartStation
														},
														m_IsConvex = C3DIfcAlignmentAddIn.CheckForConvexity(profileEntity),
														m_ParabolaConstant = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileParabolaAsymmetric.K * 100.0
															}
														}
													};
													IfcAlignment2DVerSegParabolicArc ifcAlignment2DVerSegParabolicArc3 = new IfcAlignment2DVerSegParabolicArc
													{
														m_HorizontalLength = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileParabolaAsymmetric.AsymmetricLength2
															}
														},
														m_StartHeight = new IfcLengthMeasure
														{
															_value = ifcAlignment2DVerSegParabolicArc2.m_StartHeight._value + ifcAlignment2DVerSegParabolicArc2.m_StartGradient._value * ifcAlignment2DVerSegParabolicArc2.m_HorizontalLength._value._value + ifcAlignment2DVerSegParabolicArc2.m_HorizontalLength._value._value * ifcAlignment2DVerSegParabolicArc2.m_HorizontalLength._value._value / (200.0 * ifcAlignment2DVerSegParabolicArc2.m_ParabolaConstant._value._value)
														},
														m_StartGradient = C3DIfcAlignmentAddIn.GetParabola2Gradient(profileParabolaAsymmetric),
														m_StartDistAlong = new IfcLengthMeasure
														{
															_value = profileParabolaAsymmetric.StartStation + ifcAlignment2DVerSegParabolicArc2.m_HorizontalLength._value._value
														},
														m_ParabolaConstant = new IfcPositiveLengthMeasure
														{
															_value = new IfcLengthMeasure
															{
																_value = profileParabolaAsymmetric.K * 100.0
															}
														}
													};
													ifcAlignment2DVerSegParabolicArc3.m_IsConvex = C3DIfcAlignmentAddIn.CheckForConvexity(profileEntity);
													ifcAlignment2DVertical.m_Segments.Add(ifcAlignment2DVerSegParabolicArc2);
													ifcAlignment2DVertical.m_Segments.Add(ifcAlignment2DVerSegParabolicArc3);
													ifcWriter.insertEntity(ifcAlignment2DVerSegParabolicArc2);
													ifcWriter.insertEntity(ifcAlignment2DVerSegParabolicArc3);
													break;
												}
												}
											}
										}
									}
								}
							}
							TextWriter textWriter = new StreamWriter(saveFileDialog.FileName);
							foreach (string value in ifcWriter.WriteFile())
							{
								textWriter.WriteLine(value);
							}
							textWriter.Close();
						}
					}
					if (buttonWasClicked && File.Exists(saveFileDialog.FileName))
					{
						new Success
						{
							ifcFilePath = saveFileDialog.FileName
						}.ShowDialog();
					}
				}
			}
		}

		// Token: 0x0200000A RID: 10
		public class ImportCmdHandler : ICommand
		{
			// Token: 0x06000050 RID: 80 RVA: 0x000067C0 File Offset: 0x000049C0
			public bool CanExecute(object parameter)
			{
				return true;
			}

			// Token: 0x14000002 RID: 2
			// (add) Token: 0x06000051 RID: 81 RVA: 0x00007D48 File Offset: 0x00005F48
			// (remove) Token: 0x06000052 RID: 82 RVA: 0x00007D80 File Offset: 0x00005F80
			public event EventHandler CanExecuteChanged;

			// Token: 0x06000053 RID: 83 RVA: 0x00007DB8 File Offset: 0x00005FB8
			public void Execute(object parameter)
			{
				if (parameter is RibbonButton)
				{
					string str = "";
					string text = (string)Application.GetSystemVariable("CMDNAMES");
					if (text.Length > 0)
					{
						int num = text.Split(new char[]
						{
							'\''
						}).Length;
						for (int i = 0; i < num; i++)
						{
							str += "\u0003";
						}
					}
					string text2 = parameter.GetType().GetProperty("CommandParameter").GetValue(parameter, null) as string;
					if (!string.IsNullOrEmpty(text2))
					{
						Application.DocumentManager.MdiActiveDocument.SendStringToExecute(str + text2, true, false, true);
					}
				}
			}
		}
	}
}
