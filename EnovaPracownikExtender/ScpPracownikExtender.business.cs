﻿
//----------------------------------------------------------------------------------
// <autogenerated>
//		This code was generated by a tool.
//		Changes to this file may cause incorrect behaviour and will be lost 
//		if the code is regenerated.
// </autogenerated>
//----------------------------------------------------------------------------------

using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using Soneta.Types;
using Soneta.Business;
using Soneta.Kadry;
using EnovaPracownikExtender;

[assembly: ModuleType("ScpPracownikExtender", typeof(EnovaPracownikExtender.ScpPracownikExtenderModule), 4, "ScpPracownikExtender", 1, VersionNumber=1)]

namespace EnovaPracownikExtender {

	/// <summary>
	/// Moduł ScpPracownikExtender.
	/// <seealso cref="Soneta.Kadry"/>
	/// </summary>
	/// <seealso cref="Soneta.Business.Module"/>
	/// <seealso cref="Soneta.Business.Session"/>
	[System.CodeDom.Compiler.GeneratedCode("Soneta.Generator", "4")]
	public partial class ScpPracownikExtenderModule : Module {

		public static ScpPracownikExtenderModule GetInstance(ISessionable session) => (ScpPracownikExtenderModule)session?.Session?.Modules[moduleInfo];

		private static Soneta.Business.App.ModuleInfo moduleInfo = new Soneta.Business.App.ModuleInfo(session => new ScpPracownikExtenderModule(session)) {
		};

		ScpPracownikExtenderModule(Session session) : base(session) {}

		private KadryModule moduleKadry;

		[Browsable(false)]
		public KadryModule Kadry => moduleKadry ?? (moduleKadry = KadryModule.GetInstance(Session));

		public static readonly Soneta.Business.App.TableInfo ScpPracExtTableTableInfo = new Soneta.Business.App.TableInfo.Create<ScpPracExtTable, ScpPracownikExtender, ScpPracownikExtenderRecord>("ScpExt") {
		};

		public ScpPracExtTable ScpPracExtTable => (ScpPracExtTable)Session.Tables[ScpPracExtTableTableInfo];

		private static Soneta.Business.App.KeyInfo keyInfoScpPracownikExtenderHost = new Soneta.Business.App.KeyInfo(ScpPracExtTableTableInfo, table => new ScpPracownikExtenderTable.HostRelation(table)) {
			Name = "ScpExtender",
			RelationTo = "Pracownik",
			DeleteCascade = true,
			RelationRight = RelationRightType.Primary,
			PrimaryRelation = true,
			Guided = RelationGuidedType.Inner,
			CollectionName = "ScpExtender",
			SubTableCreator = (st, row) => new SubTable<ScpPracownikExtender>(st, row),
			Unique = true,
			PrimaryKey = true,
			KeyFields = new[] {"Host"},
		};

		/// <summary>
		/// Klasa implementująca standardową obsługę tabeli obiektów ScpPracownikExtender.
		/// Dziedzicząca klasa <see cref="ScpPracExtTable"/> zawiera kod użytkownika
		/// zawierający specyficzną funkcjonalność tabeli, która nie zawiera się w funkcjonalności
		/// biblioteki <see cref="Soneta.Business"/>.
		/// </summary>
		/// <seealso cref="ScpPracExtTable"/>
		/// <seealso cref="ScpPracownikExtenderRow"/>
		/// <seealso cref="ScpPracownikExtender"/>
		/// <seealso cref="Soneta.Business.Table"/>
		public abstract partial class ScpPracownikExtenderTable : Table {

			protected ScpPracownikExtenderTable() {}

			public partial class HostRelation : Key<ScpPracownikExtender> {
				internal HostRelation(Table table) : base(table) {
				}

				protected override object[] GetData(Row row, Record rec) => new object[] {
					((ScpPracownikExtenderRecord)rec).Host
				};

				public ScpPracownikExtender this[Pracownik host] => (ScpPracownikExtender)Find(host);
			}

			public HostRelation WgHost => (HostRelation)Session.Keys[keyInfoScpPracownikExtenderHost];


			/// <summary>
			/// Typowane property dostarczające obiekt modułu zawierającegą tą tabelę. Umożliwia dostęp do
			/// innych obiektów znajdujących się w tym samym module.
			/// </summary>
			/// <seealso cref="ScpPracownikExtenderModule"/>
			public new ScpPracownikExtenderModule Module => (ScpPracownikExtenderModule)base.Module;

			public System.Linq.IQueryable<ScpPracownikExtender> AsQuery() => AsQuery<ScpPracownikExtender>();

			/// <summary>
			/// Typowany indekser dostarczający obiekty znajdujące się w tej tabeli przy pomocy 
			/// ID identyfikującego jednoznacznie obiekt w systemie.
			/// </summary>
			/// <param name="id">Liczba będąca unikalnym identyfikatorem obiektu. Wartości
			/// ujemne identyfikują obiekty, które zostały dodane i nie są jeszcze zapisane do bazy danych.</param>
			/// <seealso cref="ScpPracownikExtender"/>
			public new ScpPracownikExtender this[int id] => (ScpPracownikExtender)base[id];

			/// <summary>
			/// Typowany indekser dostarczający obiekty znajdujące się w tej tabeli przy pomocy 
			/// tablicy ID identyfikujących jednoznacznie obiekt w systemie.
			/// </summary>
			/// <param name="id">Tablica liczb będąca unikalnymi identyfikatorami obiektu. Wartości
			/// ujemne identyfikują obiekty, które zostały dodane i nie są jeszcze zapisane do bazy danych.</param>
			/// <seealso cref="ScpPracownikExtender"/>
			public new ScpPracownikExtender[] this[int[] ids] => (ScpPracownikExtender[])base[ids];

			protected override Row CreateRow(RowCreator creator) => new ScpPracownikExtender();

			[Soneta.Langs.TranslateIgnore]
			protected override sealed void PrepareNames(StringBuilder names, string divider) {
				names.Append(divider); names.Append("Host");
				names.Append(divider); names.Append("NumerButa");
			}

		}

		[Caption("Scapaflow Prac Extender")]
		public abstract partial class ScpPracownikExtenderRow : Row {

			private ScpPracownikExtenderRecord record;

			protected override void AssignRecord(Record rec) {
				record = (ScpPracownikExtenderRecord)rec;
			}

			protected ScpPracownikExtenderRow() : base(true) {
			}

			protected override Row PrimaryRow => (Row)Host;

			[Required]
			public Pracownik Host {
				get {
					if (record==null) GetRecord();
					return (Pracownik)GetRowReference(ref record.Host);
				}
				set {
					ScpPracownikExtenderSchema.HostBeforeEdit?.Invoke((ScpPracownikExtender)this, ref value);
					System.Diagnostics.Debug.Assert(value==null || State==RowState.Detached || value.State==RowState.Detached || Session==value.Session);
					GetEdit(record==null, false);
					if (value==null) throw new RequiredException(this, "Host");
					CheckAccessDenied((Row)value);
					record.Host = value;
					LockGuidedRoot();
					if (State!=RowState.Detached) {
						ResyncSet(keyInfoScpPracownikExtenderHost);
					}
					ScpPracownikExtenderSchema.HostAfterEdit?.Invoke((ScpPracownikExtender)this);
				}
			}

			public int NumerButa {
				get {
					if (record==null) GetRecord();
					return record.NumerButa;
				}
				set {
					ScpPracownikExtenderSchema.NumerButaBeforeEdit?.Invoke((ScpPracownikExtender)this, ref value);
					GetEdit(record==null, false);
					record.NumerButa = value;
					ScpPracownikExtenderSchema.NumerButaAfterEdit?.Invoke((ScpPracownikExtender)this);
				}
			}

			[Browsable(false)]
			public new ScpPracExtTable Table => (ScpPracExtTable)base.Table;

			[Browsable(false)]
			public ScpPracownikExtenderModule Module => Table.Module;

			protected override Soneta.Business.App.TableInfo TableInfo => ScpPracExtTableTableInfo;

			public sealed override AccessRights GetObjectRight() {
				AccessRights ar = CalcObjectRight();
				ScpPracownikExtenderSchema.OnCalcObjectRight?.Invoke((ScpPracownikExtender)this, ref ar);
				return ar;
			}

			protected sealed override AccessRights GetParentsObjectRight() {
				AccessRights result = CalcParentsObjectRight();
				ScpPracownikExtenderSchema.OnCalcParentsObjectRight?.Invoke((ScpPracownikExtender)this, ref result);
				return result;
			}

			protected override bool CalcReadOnly() {
				bool result = false;
				ScpPracownikExtenderSchema.OnCalcReadOnly?.Invoke((ScpPracownikExtender)this, ref result);
				return result;
			}

			protected override AccessRights CalcParentsObjectRight() {
				Row row = (Row)Host;
				return row?.GetObjectRight() ?? AccessRights.Granted;
			}

			class HostRequiredVerifier : RequiredVerifier {
				internal HostRequiredVerifier(IRow row) : base(row, "Host") {
				}
				protected override bool IsValid() => ((ScpPracownikExtenderRow)Row).Host!=null;
			}

			protected override void OnAdded() {
				base.OnAdded();
				Session.Verifiers.Add(new HostRequiredVerifier(this));
				System.Diagnostics.Debug.Assert(record.Host==null || record.Host.State==RowState.Detached || Session==record.Host.Session);
				ScpPracownikExtenderSchema.OnAdded?.Invoke((ScpPracownikExtender)this);
			}

			protected override void OnLoaded() {
				base.OnLoaded();
				ScpPracownikExtenderSchema.OnLoaded?.Invoke((ScpPracownikExtender)this);
			}

			protected override void OnEditing() {
				base.OnEditing();
				ScpPracownikExtenderSchema.OnEditing?.Invoke((ScpPracownikExtender)this);
			}

			protected override void OnDeleting() {
				base.OnDeleting();
				ScpPracownikExtenderSchema.OnDeleting?.Invoke((ScpPracownikExtender)this);
			}

			protected override void OnDeleted() {
				base.OnDeleted();
				ScpPracownikExtenderSchema.OnDeleted?.Invoke((ScpPracownikExtender)this);
			}

			protected override void OnRepacked() {
				base.OnRepacked();
				ScpPracownikExtenderSchema.OnRepacked?.Invoke((ScpPracownikExtender)this);
			}

			protected override void LockGuidedRoot() => LockGuidedRoot((Row)Host);

			public override GuidedRow GetGuidedRoot() => ((Row)Host)?.GetGuidedRoot();

		}

		public sealed class ScpPracownikExtenderRecord : Record {
			[Required]
			[ParentTable("Pracownik")]
			public IRow Host;
			public int NumerButa;

			public override Record Clone() {
				ScpPracownikExtenderRecord rec = (ScpPracownikExtenderRecord)MemberwiseClone();
				return rec;
			}

			public override void Load(RecordReader creator) {
				Host = creator.Read_Row("Pracownicy");
				NumerButa = creator.Read_int();
			}
		}

		public static class ScpPracownikExtenderSchema {

			internal static RowDelegate<ScpPracownikExtenderRow, Pracownik> HostBeforeEdit;
			public static void AddHostBeforeEdit(RowDelegate<ScpPracownikExtenderRow, Pracownik> value)
				=> HostBeforeEdit = (RowDelegate<ScpPracownikExtenderRow, Pracownik>)Delegate.Combine(HostBeforeEdit, value);

			internal static RowDelegate<ScpPracownikExtenderRow> HostAfterEdit;
			public static void AddHostAfterEdit(RowDelegate<ScpPracownikExtenderRow> value)
				=> HostAfterEdit = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(HostAfterEdit, value);

			internal static RowDelegate<ScpPracownikExtenderRow, int> NumerButaBeforeEdit;
			public static void AddNumerButaBeforeEdit(RowDelegate<ScpPracownikExtenderRow, int> value)
				=> NumerButaBeforeEdit = (RowDelegate<ScpPracownikExtenderRow, int>)Delegate.Combine(NumerButaBeforeEdit, value);

			internal static RowDelegate<ScpPracownikExtenderRow> NumerButaAfterEdit;
			public static void AddNumerButaAfterEdit(RowDelegate<ScpPracownikExtenderRow> value)
				=> NumerButaAfterEdit = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(NumerButaAfterEdit, value);

			internal static RowDelegate<ScpPracownikExtenderRow> OnLoaded;
			public static void AddOnLoaded(RowDelegate<ScpPracownikExtenderRow> value)
				=> OnLoaded = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnLoaded, value);

			internal static RowDelegate<ScpPracownikExtenderRow> OnAdded;
			public static void AddOnAdded(RowDelegate<ScpPracownikExtenderRow> value)
				=> OnAdded = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnAdded, value);

			internal static RowDelegate<ScpPracownikExtenderRow> OnEditing;
			public static void AddOnEditing(RowDelegate<ScpPracownikExtenderRow> value)
				=> OnEditing = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnEditing, value);

			internal static RowDelegate<ScpPracownikExtenderRow> OnDeleting;
			public static void AddOnDeleting(RowDelegate<ScpPracownikExtenderRow> value)
				=> OnDeleting = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnDeleting, value);

			internal static RowDelegate<ScpPracownikExtenderRow> OnDeleted;
			public static void AddOnDeleted(RowDelegate<ScpPracownikExtenderRow> value)
				=> OnDeleted = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnDeleted, value);

			internal static RowDelegate<ScpPracownikExtenderRow> OnRepacked;
			public static void AddOnRepacked(RowDelegate<ScpPracownikExtenderRow> value)
				=> OnRepacked = (RowDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnRepacked, value);

			internal static RowAccessRightsDelegate<ScpPracownikExtenderRow> OnCalcObjectRight;
			public static void AddOnCalcObjectRight(RowAccessRightsDelegate<ScpPracownikExtenderRow> value)
				=> OnCalcObjectRight = (RowAccessRightsDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnCalcObjectRight, value);

			internal static RowAccessRightsDelegate<ScpPracownikExtenderRow> OnCalcParentsObjectRight;
			public static void AddOnCalcParentsObjectRight(RowAccessRightsDelegate<ScpPracownikExtenderRow> value)
				=> OnCalcParentsObjectRight = (RowAccessRightsDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnCalcParentsObjectRight, value);

			internal static RowReadOnlyDelegate<ScpPracownikExtenderRow> OnCalcReadOnly;
			public static void AddOnCalcReadOnly(RowReadOnlyDelegate<ScpPracownikExtenderRow> value)
				=> OnCalcReadOnly = (RowReadOnlyDelegate<ScpPracownikExtenderRow>)Delegate.Combine(OnCalcReadOnly, value);

		}

	}

	[System.CodeDom.Compiler.GeneratedCode("Soneta.Generator", "4")]
	public static class StaticsScpPracownikExtenderModule {
		public static ScpPracownikExtenderModule GetScpPracownikExtender(this Session session) => ScpPracownikExtenderModule.GetInstance(session);

		public static TResult Record<TResult>(this IRecordInvoker<ScpPracownikExtender, TResult> row, Action<ScpPracownikExtenderModule.ScpPracownikExtenderRecord> action)
		    => row.InvokeAction(action, (rec, act) => ((Action<ScpPracownikExtenderModule.ScpPracownikExtenderRecord>)act)((ScpPracownikExtenderModule.ScpPracownikExtenderRecord)rec));
	}

}
