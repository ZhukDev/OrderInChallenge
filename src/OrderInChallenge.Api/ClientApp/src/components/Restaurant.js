import React from "react";
import { List, Image, Header } from 'semantic-ui-react'
import MenuItem from './MenuItem'

const Restaurant = (props) => {
  const menuItemSelected = (itemId, e) => {
    props.onItemSelected(props.id, itemId, e)
  };
  return (
    <List.Item>
        <Image src={props.logoPath} size='tiny' verticalAlign='middle' />{' '}
        <List.Content>
          <List.Header>
            <Header as='h3' color='grey'>{props.name} - {props.suburb} - rated #{props.rank} overall</Header>            
          </List.Header>
          {
            props.categories.map((x, i) => (
              <div>
                <List.Description key={i}>
                  <Header as='h4' color='grey'>{x.name}</Header>
                </List.Description>
                {x.menuItems.map((mi, j) => (
                  <List.List>
                    <MenuItem key={j} {...mi} onMenuItemSelected={menuItemSelected}/>
                  </List.List>
                ))}
              </div>
            ))
          }
          
        </List.Content>
    </List.Item>
  );
};

export default Restaurant;
