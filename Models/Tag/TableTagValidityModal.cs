using EterPharmaPro.Enums;

namespace EterPharmaPro.Models.Tag
{
	public class TableTagValidityModal
	{
		public float tableWidth { get; set; }

		public float spaceBetweenTables { get; set; }

		public float widthPercentage { get; set; }

		public float[] setWidths { get; set; }

		public float tableWidthPercentage { get; set; }

		public float tableFixedHeightHeader { get; set; }

		public float tableFixedHeightCell { get; set; }

		public float headerFont { get; set; }

		public float cellFont { get; set; }

		public TableTagValidityModal(SizeTableTagEnum sizeTable)
		{
			float[] sets = GetSize(sizeTable);
			tableWidth = sets[0];
			spaceBetweenTables = sets[1];
			widthPercentage = sets[2];
			setWidths = new float[2]
			{
			sets[3],
			sets[4]
			};
			tableWidthPercentage = sets[5];
			tableFixedHeightHeader = sets[6];
			tableFixedHeightCell = sets[7];
			headerFont = sets[8];
			cellFont = sets[9];
		}

		public static float[] GetSize(SizeTableTagEnum tableTag)
		{
			switch (tableTag)
			{
				case SizeTableTagEnum.PEQUENA:
					return new float[10] { 120f, 3f, 100f, 100f, 150f, 100f, 25f, 15f, 8f, 8f };
				case SizeTableTagEnum.MEDIA:
					return new float[10] { 150f, 3f, 150f, 130f, 180f, 130f, 25f, 20f, 8f, 8f };
				case SizeTableTagEnum.GRANDE:
					return new float[10] { 120f, 3f, 100f, 100f, 150f, 100f, 25f, 20f, 8f, 8f };
				
			}
			return null;
		}
	}
}
