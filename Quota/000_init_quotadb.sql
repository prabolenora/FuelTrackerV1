CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220914172931_initial') THEN
    CREATE TABLE "Quotas" (
        "Id" uuid NOT NULL,
        "vehicleRegistrationNumber" text NULL,
        "maxQuota" double precision NULL,
        "remainingQuota" double precision NULL,
        CONSTRAINT "PK_Quotas" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220914172931_initial') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220914172931_initial', '6.0.8');
    END IF;
END $EF$;
COMMIT;

