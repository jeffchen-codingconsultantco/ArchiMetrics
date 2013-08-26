// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operands.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2012
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the Operands type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ArchiMetrics.Analysis.Metrics
{
	using System.Collections.Generic;
	using Roslyn.Compilers.CSharp;

	internal sealed class Operands
	{
		public static readonly IEnumerable<SyntaxKind> All = new[]
			                                                     {
				                                                     SyntaxKind.IdentifierToken, 
				                                                     SyntaxKind.StringLiteralToken, 
				                                                     SyntaxKind.NumericLiteralToken, 
				                                                     SyntaxKind.AddKeyword, 
				                                                     SyntaxKind.AliasKeyword, 
				                                                     SyntaxKind.AscendingKeyword, 
				                                                     SyntaxKind.AsKeyword, 
				                                                     SyntaxKind.AsyncKeyword, 
				                                                     SyntaxKind.AwaitKeyword, 
				                                                     SyntaxKind.BaseKeyword, 
				                                                     SyntaxKind.BoolKeyword, 
				                                                     SyntaxKind.BreakKeyword, 
				                                                     SyntaxKind.ByKeyword, 
				                                                     SyntaxKind.ByteKeyword, 
				                                                     SyntaxKind.CaseKeyword, 
				                                                     SyntaxKind.CatchKeyword, 
				                                                     SyntaxKind.CharKeyword, 
				                                                     SyntaxKind.CheckedKeyword, 
				                                                     SyntaxKind.ChecksumKeyword, 
				                                                     SyntaxKind.ClassKeyword, 
				                                                     SyntaxKind.ConstKeyword, 
				                                                     SyntaxKind.ContinueKeyword, 
				                                                     SyntaxKind.DecimalKeyword, 
				                                                     SyntaxKind.DefaultKeyword, 
				                                                     SyntaxKind.DefineKeyword, 
				                                                     SyntaxKind.DelegateKeyword, 
				                                                     SyntaxKind.DescendingKeyword, 
				                                                     SyntaxKind.DisableKeyword, 
				                                                     SyntaxKind.DoKeyword, 
				                                                     SyntaxKind.DoubleKeyword, 
				                                                     SyntaxKind.ElifKeyword, 
				                                                     SyntaxKind.ElseKeyword, 
				                                                     SyntaxKind.EndIfKeyword, 
				                                                     SyntaxKind.EndRegionKeyword, 
				                                                     SyntaxKind.EnumKeyword, 
				                                                     SyntaxKind.EqualsKeyword, 
				                                                     SyntaxKind.ErrorKeyword, 
				                                                     SyntaxKind.EventKeyword, 
				                                                     SyntaxKind.ExplicitKeyword, 
				                                                     SyntaxKind.ExternKeyword, 
				                                                     SyntaxKind.FalseKeyword, 
				                                                     SyntaxKind.FieldKeyword, 
				                                                     SyntaxKind.FinallyKeyword, 
				                                                     SyntaxKind.FixedKeyword, 
				                                                     SyntaxKind.FloatKeyword, 
				                                                     SyntaxKind.ForEachKeyword, 
				                                                     SyntaxKind.ForKeyword, 
				                                                     SyntaxKind.FromKeyword, 
				                                                     SyntaxKind.GetKeyword, 
				                                                     SyntaxKind.GlobalKeyword, 
				                                                     SyntaxKind.GotoKeyword, 
				                                                     SyntaxKind.GroupKeyword, 
				                                                     SyntaxKind.HiddenKeyword, 
				                                                     SyntaxKind.IfKeyword, 
				                                                     SyntaxKind.ImplicitKeyword, 
				                                                     SyntaxKind.InKeyword, 
				                                                     SyntaxKind.InterfaceKeyword, 
				                                                     SyntaxKind.InternalKeyword, 
				                                                     SyntaxKind.IntKeyword, 
				                                                     SyntaxKind.IntoKeyword, 
				                                                     SyntaxKind.IsKeyword, 
				                                                     SyntaxKind.JoinKeyword, 
				                                                     SyntaxKind.LetKeyword, 
				                                                     SyntaxKind.LineKeyword, 
				                                                     SyntaxKind.LockKeyword, 
				                                                     SyntaxKind.LongKeyword, 
				                                                     SyntaxKind.MakeRefKeyword, 
				                                                     SyntaxKind.MethodKeyword, 
				                                                     SyntaxKind.ModuleKeyword, 
				                                                     SyntaxKind.NamespaceKeyword, 
				                                                     SyntaxKind.NullKeyword, 
				                                                     SyntaxKind.ObjectKeyword, 
				                                                     SyntaxKind.OnKeyword, 
				                                                     SyntaxKind.OperatorKeyword, 
				                                                     SyntaxKind.OrderByKeyword, 
				                                                     SyntaxKind.OutKeyword, 
				                                                     SyntaxKind.OverrideKeyword, 
				                                                     SyntaxKind.ParamKeyword, 
				                                                     SyntaxKind.ParamsKeyword, 
				                                                     SyntaxKind.PartialKeyword, 
				                                                     SyntaxKind.PragmaKeyword, 
				                                                     SyntaxKind.PrivateKeyword, 
				                                                     SyntaxKind.PropertyKeyword, 
				                                                     SyntaxKind.ProtectedKeyword, 
				                                                     SyntaxKind.PublicKeyword, 
				                                                     SyntaxKind.ReadOnlyKeyword, 
				                                                     SyntaxKind.ReferenceKeyword, 
				                                                     SyntaxKind.RefKeyword, 
				                                                     SyntaxKind.RefTypeKeyword, 
				                                                     SyntaxKind.RefValueKeyword, 
				                                                     SyntaxKind.RegionKeyword, 
				                                                     SyntaxKind.RemoveKeyword, 
				                                                     SyntaxKind.RestoreKeyword, 
				                                                     SyntaxKind.ReturnKeyword, 
				                                                     SyntaxKind.SByteKeyword, 
				                                                     SyntaxKind.SealedKeyword, 
				                                                     SyntaxKind.SelectKeyword, 
				                                                     SyntaxKind.SetKeyword, 
				                                                     SyntaxKind.ShortKeyword, 
				                                                     SyntaxKind.SizeOfKeyword, 
				                                                     SyntaxKind.StackAllocKeyword, 
				                                                     SyntaxKind.StaticKeyword, 
				                                                     SyntaxKind.StringKeyword, 
				                                                     SyntaxKind.StructKeyword, 
				                                                     SyntaxKind.SwitchKeyword, 
				                                                     SyntaxKind.ThisKeyword, 
				                                                     SyntaxKind.TrueKeyword, 
				                                                     SyntaxKind.TryKeyword, 
				                                                     SyntaxKind.TypeKeyword, 
				                                                     SyntaxKind.TypeOfKeyword, 
				                                                     SyntaxKind.TypeVarKeyword, 
				                                                     SyntaxKind.UIntKeyword, 
				                                                     SyntaxKind.ULongKeyword, 
				                                                     SyntaxKind.UncheckedKeyword, 
				                                                     SyntaxKind.UndefKeyword, 
				                                                     SyntaxKind.UnsafeKeyword, 
				                                                     SyntaxKind.UShortKeyword, 
				                                                     SyntaxKind.UsingKeyword, 
				                                                     SyntaxKind.VirtualKeyword, 
				                                                     SyntaxKind.VoidKeyword, 
				                                                     SyntaxKind.VolatileKeyword, 
				                                                     SyntaxKind.WarningKeyword, 
				                                                     SyntaxKind.WhereKeyword, 
				                                                     SyntaxKind.WhileKeyword, 
				                                                     SyntaxKind.YieldKeyword
			                                                     };
	}
}