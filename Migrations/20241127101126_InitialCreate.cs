using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmacyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    last_name = table.Column<string>(
                        type: "nvarchar(50)",
                        maxLength: 50,
                        nullable: false
                    ),
                    phone_number = table.Column<string>(
                        type: "varchar(15)",
                        unicode: false,
                        maxLength: 15,
                        nullable: false
                    ),
                    address = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: true
                    ),
                    gender = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(
                        type: "varchar(15)",
                        unicode: false,
                        maxLength: 15,
                        nullable: false
                    )
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: false
                    ),
                    barcode = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: false
                    ),
                    requires_prescription = table.Column<bool>(type: "bit", nullable: false),
                    frequency_limit_days = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    form = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    category_id = table.Column<long>(type: "bigint", nullable: false),
                    manufacturer_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_product_manufacturer_manufacturer_id",
                        column: x => x.manufacturer_id,
                        principalTable: "manufacturer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    person_id = table.Column<long>(type: "bigint", nullable: false),
                    customer_number = table.Column<long>(type: "bigint", nullable: false),
                    is_blocked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    person_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supplier", x => x.id);
                    table.ForeignKey(
                        name: "FK_supplier_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "batch",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    total_cost = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    supplier_id = table.Column<long>(type: "bigint", nullable: false),
                    branch_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_batch", x => x.id);
                    table.ForeignKey(
                        name: "FK_batch_supplier_supplier_id",
                        column: x => x.supplier_id,
                        principalTable: "supplier",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "product_batch",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    batch_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<long>(type: "bigint", nullable: false),
                    cost_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    selling_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    expiration_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_batch", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_batch_batch_batch_id",
                        column: x => x.batch_id,
                        principalTable: "batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_product_batch_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "branch",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    longitude = table.Column<string>(
                        type: "varchar(15)",
                        unicode: false,
                        maxLength: 15,
                        nullable: false
                    ),
                    latitude = table.Column<string>(
                        type: "varchar(15)",
                        unicode: false,
                        maxLength: 15,
                        nullable: false
                    ),
                    manager_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: false
                    ),
                    password = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: false
                    ),
                    is_admin = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    person_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<long>(type: "bigint", nullable: false),
                    manager_id = table.Column<long>(type: "bigint", nullable: true),
                    branch_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branch",
                        principalColumn: "id"
                    );
                    table.ForeignKey(
                        name: "FK_user_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_user_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_user_user_manager_id",
                        column: x => x.manager_id,
                        principalTable: "user",
                        principalColumn: "id"
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "inventory_adjustment",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reason = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(
                        type: "varchar(255)",
                        unicode: false,
                        maxLength: 255,
                        nullable: true
                    ),
                    quantity_change = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    product_batch_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_adjustment", x => x.id);
                    table.ForeignKey(
                        name: "FK_inventory_adjustment_product_batch_product_batch_id",
                        column: x => x.product_batch_id,
                        principalTable: "product_batch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_inventory_adjustment_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "sale",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    customer_id = table.Column<long>(type: "bigint", nullable: false),
                    branch_id = table.Column<long>(type: "bigint", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sale", x => x.id);
                    table.ForeignKey(
                        name: "FK_sale_branch_branch_id",
                        column: x => x.branch_id,
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_sale_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_sale_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "product_sale",
                columns: table => new
                {
                    id = table
                        .Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sale_id = table.Column<long>(type: "bigint", nullable: false),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_sale", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_sale_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        name: "FK_product_sale_sale_sale_id",
                        column: x => x.sale_id,
                        principalTable: "sale",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_batch_branch_id",
                table: "batch",
                column: "branch_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_batch_supplier_id",
                table: "batch",
                column: "supplier_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_branch_manager_id",
                table: "branch",
                column: "manager_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_customer_person_id",
                table: "customer",
                column: "person_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_inventory_adjustment_product_batch_id",
                table: "inventory_adjustment",
                column: "product_batch_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_inventory_adjustment_user_id",
                table: "inventory_adjustment",
                column: "user_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_manufacturer_id",
                table: "product",
                column: "manufacturer_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_batch_batch_id",
                table: "product_batch",
                column: "batch_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_batch_product_id",
                table: "product_batch",
                column: "product_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_sale_product_id",
                table: "product_sale",
                column: "product_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_product_sale_sale_id",
                table: "product_sale",
                column: "sale_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_sale_branch_id",
                table: "sale",
                column: "branch_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_sale_customer_id",
                table: "sale",
                column: "customer_id"
            );

            migrationBuilder.CreateIndex(name: "IX_sale_user_id", table: "sale", column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_person_id",
                table: "supplier",
                column: "person_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_user_branch_id",
                table: "user",
                column: "branch_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_user_manager_id",
                table: "user",
                column: "manager_id"
            );

            migrationBuilder.CreateIndex(
                name: "IX_user_person_id",
                table: "user",
                column: "person_id"
            );

            migrationBuilder.CreateIndex(name: "IX_user_role_id", table: "user", column: "role_id");

            migrationBuilder.CreateIndex(
                name: "unique_email",
                table: "user",
                column: "email",
                unique: true
            );

            migrationBuilder.AddForeignKey(
                name: "FK_batch_branch_branch_id",
                table: "batch",
                column: "branch_id",
                principalTable: "branch",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict
            );

            migrationBuilder.AddForeignKey(
                name: "FK_branch_user_manager_id",
                table: "branch",
                column: "manager_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_user_branch_branch_id", table: "user");

            migrationBuilder.DropTable(name: "inventory_adjustment");

            migrationBuilder.DropTable(name: "product_sale");

            migrationBuilder.DropTable(name: "product_batch");

            migrationBuilder.DropTable(name: "sale");

            migrationBuilder.DropTable(name: "batch");

            migrationBuilder.DropTable(name: "product");

            migrationBuilder.DropTable(name: "customer");

            migrationBuilder.DropTable(name: "supplier");

            migrationBuilder.DropTable(name: "category");

            migrationBuilder.DropTable(name: "manufacturer");

            migrationBuilder.DropTable(name: "branch");

            migrationBuilder.DropTable(name: "user");

            migrationBuilder.DropTable(name: "person");

            migrationBuilder.DropTable(name: "role");
        }
    }
}
