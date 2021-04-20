import React from "react";
import { List, Checkbox, Header } from 'semantic-ui-react'

const MenuItem = (props) => {
  return (
    <List.Item>
        <List.Content>
          <List.Header>
            <Header as='h4' color='grey'>
              <Checkbox checked={props.checked} onChange={() => props.onMenuItemSelected(props)} label={{ children: `${props.name} - R${props.price}` }} />
            </Header>
          </List.Header>          
        </List.Content>
    </List.Item>
  );
};

export default MenuItem;
