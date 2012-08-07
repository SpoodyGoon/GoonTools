using System;
using SQLiteMonoPlusUI.Schema;

namespace SQLiteMonoPlusUI
{
	public partial class frmPragmas : Gtk.Dialog
	{
		public frmPragmas (Database db)
		{
			this.Build ();

			if (db.Pragmas.ContainsKey ("auto_vacuum")) {

				//cboAutoVacuum. = db.Pragmas["auto_vacuum"].ToString();
			}
			/*
				"automatic_index",
				"cache_size",
				"case_sensitive_like",
				"checkpoint_fullfsync",
				"encoding",
				"foreign_keys",
				"ignore_check_constraints",
				"journal_mode",
				"journal_size_limit",
				"legacy_file_format",
				"locking_mode",
				"max_page_count",
				"page_size",
				"quick_check",
				"read_uncommitted",
				"recursive_triggers",
				"reverse_unordered_selects",
				"schema_version",
				"secure_delete",
				"synchronous",
				"temp_store",
				"user_version",
				"wal_autocheckpoint",
				"wal_checkpoint",
				"writable_schema"
				*/
		}
	}
}

