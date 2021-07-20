import React from "react";
import { BrowserRouter, Route, Switch } from "react-router-dom";
import AddProject from "../components/AddProject";
import App from "../App";
import NotFound from "../views/NotFound";

const Router = () => (
  <BrowserRouter>
    <Switch>
      <Route exact path="/" component={App} />
      <Route path="/addproject" component={AddProject} />
      <Route component={NotFound} />
    </Switch>
  </BrowserRouter>
);

export default Router; 