import { isRouteErrorResponse, useRouteError } from "react-router-dom";

import PageContent from "../components/PageContent";

export default function ErrorPage() {
  const error = useRouteError();
  console.log(error);

  let title = "An error occurred!";
  let message = "Something went wrong!";

  if (isRouteErrorResponse(error)) {
    // Usa los datos proporcionados por el loader en el error
    title = error.data?.title || title;
    message = error.data?.message || message;
  }

  return (
    <>
      <PageContent title={title}>
        <p>{message}</p>
      </PageContent>
    </>
  );
}
