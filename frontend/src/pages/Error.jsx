import { isRouteErrorResponse, useRouteError } from "react-router-dom";

import PageContent from "../components/PageContent";

export default function ErrorPage() {
  const error = useRouteError();
  console.log(error);

  let title = "An error occurred!";
  let message = "Something went wrong!";

  if (isRouteErrorResponse(error) && error.status === 403) {
    title = error.data.title;
    message = error.data.message;
  }

  return (
    <>
      <PageContent title={title}>
        <p>{message}</p>
      </PageContent>
    </>
  );
}
