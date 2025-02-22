using System;

namespace EterPharmaPro.Enums
{
	[Flags]
	public enum PermissionsEnum
	{
		Padrao = 0,
		Dev = 1 << 0,         // 1
		Admin = 1 << 1,       // 2
		Supervisor = 1 << 2,  // 4
		Gerente = 1 << 3,     // 8
		Farmaceutico = 1 << 4,// 16
		Balconista = 1 << 5,  // 32
		OperadorLoja = 1 << 6,// 64
		OperadorCaixa = 1 << 7,// 128
		Entregador = 1 << 8,  // 256
		Perfumista = 1 << 9   // 512
	}
	//[Flags]
	//public enum PermissionsEnum
	//{
	//	Nenhuma = 0,
	//	Padrao = 1,           // 00000000001
	//	Dev = 2,              // 00000000010
	//	Admin = 4,            // 00000000100
	//	Supervisor = 8,       // 00000001000
	//	Gerente = 16,         // 00000010000
	//	Farmaceutico = 32,    // 00000100000
	//	Balconista = 64,      // 00001000000
	//	OperadorLoja = 128,   // 00010000000
	//	OperadorCaixa = 256,  // 00100000000
	//	Entregador = 512,     // 01000000000
	//	Perfumista = 1024     // 10000000000
	//}
}
