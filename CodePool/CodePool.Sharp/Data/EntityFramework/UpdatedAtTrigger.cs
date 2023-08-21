using Microsoft.EntityFrameworkCore.Migrations;

namespace CodePool.Sharp.Data.EntityFramework;

public static class UpdatedAtTrigger
{
    public static void CreateUpdatedAtTrigger(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
            CREATE OR REPLACE FUNCTION trigger_set_updated_at()
            RETURNS TRIGGER AS $$
            BEGIN
            NEW.updated_at = NOW();
            RETURN NEW;
            END;
            $$ LANGUAGE plpgsql;
        ");

        migrationBuilder.Sql(@"
            CREATE OR REPLACE FUNCTION updated_tables_with_trigger_updated_at()
            RETURNS TRIGGER AS $$
                DECLARE
                    r RECORD;
                BEGIN
                FOR r IN (
                    SELECT information_schema.tables.table_name
                    FROM information_schema.tables
                    JOIN information_schema.columns
                    ON
                            information_schema.columns.table_name = information_schema.tables.table_name
                        AND information_schema.columns.column_name = 'updated_at'
                    LEFT JOIN information_schema.triggers
                    ON
                        information_schema.triggers.event_object_table = information_schema.tables.table_name
                    WHERE
                        information_schema.tables.table_schema NOT IN (
                            'information_schema',
                            'pg_catalog'
                        )
                        AND information_schema.triggers.trigger_name IS NULL
                )
                LOOP
                    RAISE NOTICE 'CREATE TRIGGER FOR: %', r.table_name::text;

                    EXECUTE 'CREATE TRIGGER set_updated_at
                    BEFORE UPDATE
                    on ' || r.table_name || ' FOR EACH ROW
                    EXECUTE PROCEDURE trigger_set_updated_at();';
                END LOOP;
                RETURN NULL;
                END;
            $$ LANGUAGE plpgsql;
        ");

        migrationBuilder.Sql(@"
            CREATE TRIGGER trigger_run_function_updated_at_tables
            AFTER INSERT OR UPDATE OR DELETE OR TRUNCATE ON ""__EFMigrationsHistory""
            FOR EACH STATEMENT
            EXECUTE FUNCTION updated_tables_with_trigger_updated_at();
        ");
    }

    public static void DropUpdatedAtTrigger(this MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"
            DROP TRIGGER trigger_run_function_updated_at_tables
            ON ""__EFMigrationsHistory"";
        ");
        migrationBuilder.Sql("DROP FUNCTION updated_tables_with_trigger_updated_at");
        migrationBuilder.Sql("DROP FUNCTION trigger_set_updated_at");
    }
}
