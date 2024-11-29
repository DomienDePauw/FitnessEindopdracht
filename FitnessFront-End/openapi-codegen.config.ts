import {
    generateSchemaTypes,
    generateReactQueryComponents,
  } from "@openapi-codegen/typescript";
  import { defineConfig } from "@openapi-codegen/cli";
  
  export default defineConfig({
    fitness: {
      from: {
        url:
          "http://localhost:5151/swagger/v1/swagger.json",
        source: "url",
      },
      outputDir: "src/endpoints",
      to: async (context) => {
        const filenamePrefix = "fitness";
        const { schemasFiles } = await generateSchemaTypes(context, {
          filenamePrefix,
        });
        await generateReactQueryComponents(context, {
          filenamePrefix,
          schemasFiles,
        });
      },
    },
  });