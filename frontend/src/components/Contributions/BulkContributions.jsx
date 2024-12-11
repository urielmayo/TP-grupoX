import { useState } from "react";
import { Form, useActionData } from "react-router-dom";

import SubmitButton from "../UI/form/SubmitButton";
import FormTitle from "../UI/form/FormTitle";
import FormLayout from "../UI/form/FormLayout";

export default function FileUploadForm() {
  const [file, setFile] = useState(null);
  const actionData = useActionData();

  const handleFileChange = (e) => {
    console.log(e.target.files[0].name);

    setFile(e.target.files[0]);
  };

  return (
    <FormLayout>
      <Form method="post" encType="multipart/form-data">
        <FormTitle text="Carga de Contribuciones por Archivo" />
        <br />
        <div className="flex items-center justify-center w-full">
          <label
            htmlFor="dropzone-file"
            className="flex flex-col items-center justify-center w-full h-64 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 hover:bg-gray-100"
          >
            <div className="flex flex-col items-center justify-center pt-5 pb-6">
              <svg
                className="w-8 h-8 mb-4 text-gray-500 dark:text-gray-400"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 20 16"
              >
                <path
                  stroke="currentColor"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="2"
                  d="M13 13h3a3 3 0 0 0 0-6h-.025A5.56 5.56 0 0 0 16 6.5 5.5 5.5 0 0 0 5.207 5.021C5.137 5.017 5.071 5 5 5a4 4 0 0 0 0 8h2.167M10 15V6m0 0L8 8m2-2 2 2"
                />
              </svg>
              <p className="mb-2 text-sm text-gray-500 dark:text-gray-400">
                <span className="font-semibold">Haga click</span> o arrastre su
                archivo CSV
              </p>
              <p className="text-xs text-gray-500 dark:text-gray-400">
                {file?.name || "Ningun archivo seleccionado"}
              </p>
            </div>
            <input
              id="dropzone-file"
              name="file"
              type="file"
              accept=".csv"
              onChange={handleFileChange}
              className="hidden"
            />
          </label>
        </div>
        {actionData?.error && (
          <div className="text-red-500 text-sm mt-2">{actionData.error}</div>
        )}
        <SubmitButton text="Cargar Contribuciones" />
      </Form>

      {actionData?.success && (
        <div className="mt-4 text-green-500 text-sm">
          Archivo cargado exitosamente.
        </div>
      )}
    </FormLayout>
  );
}
