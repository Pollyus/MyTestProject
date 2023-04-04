import React from "react";
import { storiesOf } from "@storybook/react";
import Button from "./Button";

// You can see this as "folders" in Storybook's sidebar
const stories = storiesOf("atoms/Button", module);

// Every story represents a state for our Button component
stories.add("default", () => <Button>Button</Button>);
stories.add("default disabled", () => <Button disabled>Button</Button>);
stories.add("primary", () => <Button variant="primary">Button</Button>);
// Passing a prop without a value is basically the same as passing `true`
stories.add("primary disabled", () => (
  <Button variant="primary" disabled>
    Button
  </Button>
));
stories.add("secondary", () => <Button variant="secondary">Button</Button>);
stories.add("secondary disabled", () => (
  <Button variant="secondary" disabled>
    Button
  </Button>
));